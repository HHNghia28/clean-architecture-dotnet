﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Product.Infrastructure.Context;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Product.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5649),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5651),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Coffee"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5690),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5690),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Tea"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5692),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5692),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Banh Mi"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5694),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5694),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5793),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5793),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "PhinDi Cassia",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                            Price = 55000,
                            Quantity = 325
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5801),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                            Discount = 5,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5801),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Phindi Hạt Dẻ Cười",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                            Price = 65000,
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5805),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5805),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "PhinDi Choco",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg",
                            Price = 45000,
                            Quantity = 5
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                            CategoryId = 2,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5808),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Golden Lotus Tea (Only Lotus seed)",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5809),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Golden Lotus Tea (Only Lotus seed)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg",
                            Price = 45000,
                            Quantity = 214
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                            CategoryId = 2,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5812),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!",
                            Discount = 10,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5812),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Peach Jelly Tea",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg",
                            Price = 45000,
                            Quantity = 45
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                            CategoryId = 3,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5815),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5815),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Bánh Mì Que (Gà Phô Mai)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png",
                            Price = 19000,
                            Quantity = 34
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                            CategoryId = 3,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5819),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5819),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "Bánh Mì Que (Pate)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png",
                            Price = 19000,
                            Quantity = 146
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                            CategoryId = 4,
                            CreatedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5822),
                            CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Description = "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)",
                            Discount = 3,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 18, 11, 3, 44, 343, DateTimeKind.Utc).AddTicks(5822),
                            LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                            Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                            Price = 109000,
                            Quantity = 214
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.Product", b =>
                {
                    b.HasOne("Product.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Product.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
