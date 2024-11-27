using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4394), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4396), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Coffee" },
                    { 2, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4413), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4413), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Tea" },
                    { 3, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4418), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4418), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Banh Mi" },
                    { 4, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4421), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4421), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "Description", "Discount", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { new Guid("00f8067b-8d13-45d8-86b3-0a7b20e10aa6"), 1, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4599), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!", 0, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4599), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "PhinDi Choco", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg", 45000 },
                    { new Guid("7dbe07da-48b4-48d2-93de-f357430cfb46"), 2, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4608), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!", 10, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4608), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Peach Jelly Tea", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg", 45000 },
                    { new Guid("9ac7e389-fcea-4c2c-80b6-59ec62085d1e"), 3, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4612), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.", 0, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4612), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Bánh Mì Que (Gà Phô Mai)", "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png", 19000 },
                    { new Guid("b57573e7-2011-4653-b1eb-66bc0a14fb80"), 1, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4573), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.", 0, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4573), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "PhinDi Cassia", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000 },
                    { new Guid("cd632a44-d263-47c4-8f2a-a4fc16a36b5f"), 3, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4631), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.", 0, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4631), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Bánh Mì Que (Pate)", "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png", 19000 },
                    { new Guid("e541805a-dfb5-45c3-9016-31b765aeeea5"), 2, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4603), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Golden Lotus Tea (Only Lotus seed)", 0, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4603), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Golden Lotus Tea (Only Lotus seed)", "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg", 45000 },
                    { new Guid("eb368244-1230-4f2e-ba68-ee9bfc89d1c8"), 1, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4594), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!", 5, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4594), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Phindi Hạt Dẻ Cười", "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000 },
                    { new Guid("f07fa654-8a94-4575-b694-7f87964e8f14"), 4, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4636), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)", 3, false, new DateTime(2024, 11, 26, 7, 38, 45, 778, DateTimeKind.Utc).AddTicks(4636), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
