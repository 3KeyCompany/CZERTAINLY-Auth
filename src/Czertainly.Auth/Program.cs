using Czertainly.Auth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Czertainly.Auth.Data.Contracts;
using Czertainly.Auth.Data.Repositiories;
using Czertainly.Auth.Services;
using Czertainly.Auth.Common.Filters;
using NLog.Web;
using NLog;
using Czertainly.Auth.Common.Exceptions;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddAutoMapper(cfg =>
    {
        cfg.AllowNullCollections = true;
    }, typeof(Program));
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            //options.SuppressInferBindingSourcesForParameters = true;
        });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(swagger =>
    {
        swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Czertainly Auth Service", Version = "v1" });
    });

    builder.Services.AddApiVersioning(o =>
    {
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
        o.ReportApiVersions = true;
    });

    builder.Services.AddDbContext<AuthDbContext>(opts =>
    {
        opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), pgsqlOpts =>
        {
            pgsqlOpts.MigrationsHistoryTable("_migrations_history", "auth");
        });
    });

    // add app services
    builder.Services.AddScoped<ValidationFilter>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddScoped<IPermissionService, PermissionService>();
    builder.Services.AddScoped<IResourceService, ResourceService>();
    builder.Services.AddScoped<IActionService, ActionService>();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // run migrations
    // TODO: handle migrations differently in production, not run during deployment
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
        dataContext.Database.Migrate();
    }

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}