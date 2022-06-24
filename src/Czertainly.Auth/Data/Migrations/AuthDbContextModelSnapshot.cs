﻿// <auto-generated />
using System;
using Czertainly.Auth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Czertainly.Auth.Data.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    partial class AuthDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auth")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Endpoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ActionName")
                        .HasColumnType("text")
                        .HasColumnName("action_name");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ResourceName")
                        .HasColumnType("text")
                        .HasColumnName("resource_name");

                    b.Property<string>("RouteTemplate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("route_template");

                    b.Property<string>("ServiceName")
                        .HasColumnType("text")
                        .HasColumnName("service_name");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("endpoint", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EndpointId")
                        .HasColumnType("bigint")
                        .HasColumnName("endpoint_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EndpointId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("permission", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("role", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool?>("Enabled")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("enabled");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("user", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.UserAuthInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CertificateFingerprint")
                        .HasColumnType("text")
                        .HasColumnName("certificate_fingerprint");

                    b.Property<string>("CertificateSerialNumber")
                        .HasColumnType("text")
                        .HasColumnName("certificate_serial_number");

                    b.Property<string>("CertificateUuid")
                        .HasColumnType("text")
                        .HasColumnName("certificate_uuid");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("user_auth_info", "auth");
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.Property<long>("role_id")
                        .HasColumnType("bigint");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("role_id", "user_id");

                    b.HasIndex("user_id");

                    b.ToTable("user_role", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Permission", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.Endpoint", "Endpoint")
                        .WithMany("Permissions")
                        .HasForeignKey("EndpointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Czertainly.Auth.Models.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endpoint");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.UserAuthInfo", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.User", "User")
                        .WithOne("UserAuthInfo")
                        .HasForeignKey("Czertainly.Auth.Models.Entities.UserAuthInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Czertainly.Auth.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Endpoint", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.User", b =>
                {
                    b.Navigation("UserAuthInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
