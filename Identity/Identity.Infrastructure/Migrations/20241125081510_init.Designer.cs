﻿// <auto-generated />
using System;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125081510_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Identity.Domain.Entities.EmailConfirmationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailConfirmationTokens");
                });

            modelBuilder.Entity("Identity.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Identity.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "STaff"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be5d078f-b1b6-4945-bdc8-52acc1de1416"),
                            CreatedAt = new DateTime(2024, 11, 25, 8, 15, 9, 612, DateTimeKind.Utc).AddTicks(1010),
                            Email = "admin@gmail.com",
                            FullName = "admin",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2024, 11, 25, 8, 15, 9, 612, DateTimeKind.Utc).AddTicks(1023),
                            PasswordHash = "$2a$11$aUwagqrB//R/Ku7h5yjFou9utBFa1jOYcUBPeyQbM8tsqWbFjr0TO",
                            RoleId = 1
                        },
                        new
                        {
                            Id = new Guid("1218f87f-eab3-4e94-bd54-d0c3b38491b1"),
                            CreatedAt = new DateTime(2024, 11, 25, 8, 15, 9, 796, DateTimeKind.Utc).AddTicks(6494),
                            Email = "staff@gmail.com",
                            FullName = "staff",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2024, 11, 25, 8, 15, 9, 796, DateTimeKind.Utc).AddTicks(6497),
                            PasswordHash = "$2a$11$Xyrc0YTgLwh24oKk88gz5.v8E2p9ez7T928ad5ViUV7ga76o3mZw.",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("47f55a0c-6cd1-4173-a4b9-4c80fca90a31"),
                            CreatedAt = new DateTime(2024, 11, 25, 8, 15, 9, 980, DateTimeKind.Utc).AddTicks(9377),
                            Email = "user@gmail.com",
                            FullName = "user",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2024, 11, 25, 8, 15, 9, 980, DateTimeKind.Utc).AddTicks(9379),
                            PasswordHash = "$2a$11$ob1eZXPISr0qQEHIWyMUzuu8UeZ5QMRY7eCgscY0bhp4HNtyYdoXu",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Identity.Domain.Entities.EmailConfirmationToken", b =>
                {
                    b.HasOne("Identity.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Identity.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Identity.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Identity.Domain.Entities.User", b =>
                {
                    b.HasOne("Identity.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Identity.Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}