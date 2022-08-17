﻿// <auto-generated />
using System;
using Czertainly.Auth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Czertainly.Auth.Data.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20220716235608_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auth")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Action", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("ResourceId")
                        .HasColumnType("bigint")
                        .HasColumnName("resource_id");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("action", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Endpoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ActionId")
                        .HasColumnType("bigint")
                        .HasColumnName("action_id");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("ResourceId")
                        .HasColumnType("bigint")
                        .HasColumnName("resource_id");

                    b.Property<string>("RouteTemplate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("route_template");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ResourceId");

                    b.ToTable("endpoint", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ActionId")
                        .HasColumnType("bigint")
                        .HasColumnName("action_id");

                    b.Property<bool>("IsAllowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_allowed");

                    b.Property<Guid?>("ObjectUuid")
                        .HasColumnType("uuid")
                        .HasColumnName("object_uuid");

                    b.Property<long?>("ResourceId")
                        .HasColumnType("bigint")
                        .HasColumnName("resource_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("permission", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ListingEndpoint")
                        .HasColumnType("text")
                        .HasColumnName("listing_endpoint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("resource", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

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
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("role", "auth");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CertificateFingerprint")
                        .HasColumnType("text")
                        .HasColumnName("certificate_fingerprint");

                    b.Property<Guid?>("CertificateUuid")
                        .HasColumnType("uuid")
                        .HasColumnName("certificate_uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("Enabled")
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
                        .HasColumnName("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("user", "auth");
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

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Action", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Endpoint", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Czertainly.Auth.Models.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Permission", b =>
                {
                    b.HasOne("Czertainly.Auth.Models.Entities.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Czertainly.Auth.Models.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("Czertainly.Auth.Models.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Resource");

                    b.Navigation("Role");
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

            modelBuilder.Entity("Czertainly.Auth.Models.Entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
