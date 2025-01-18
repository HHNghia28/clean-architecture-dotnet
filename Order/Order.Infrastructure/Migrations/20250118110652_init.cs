using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ShippingFee = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    VoucherName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VoucherValue = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Photo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Discount", "FullName", "LastModifiedAt", "LastModifiedBy", "Note", "Phone", "ShippingFee", "Status", "TotalPrice", "VoucherCode", "VoucherName", "VoucherValue" },
                values: new object[] { new Guid("fb670327-720a-4b6a-9f67-9e65a9d8ce08"), "Cần Thơ", new DateTime(2025, 1, 18, 11, 6, 52, 513, DateTimeKind.Utc).AddTicks(9828), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), 0, "Huỳnh Hữu Nghĩa", new DateTime(2025, 1, 18, 11, 6, 52, 513, DateTimeKind.Utc).AddTicks(9829), new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"), "Giao hàng nhanh", "0832474699", 32000, 0, 289814, "NGHIAHH", "Voucher 28/08", 24 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Category", "Description", "Discount", "Name", "OrderId", "Photo", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("09adeef3-9a8e-4dc8-ae4a-ced34750665d"), "Coffee", "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!", 5, "Phindi Hạt Dẻ Cười", new Guid("fb670327-720a-4b6a-9f67-9e65a9d8ce08"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg", 65000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"), 2 },
                    { new Guid("3ff62263-b826-4a0d-b946-2057c863dd78"), "Other", "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)", 3, "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE", new Guid("fb670327-720a-4b6a-9f67-9e65a9d8ce08"), "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png", 109000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"), 1 },
                    { new Guid("dde5efe8-9d62-4920-b2ae-2eb1f9dab0fb"), "Coffee", "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.", 0, "PhinDi Cassia", new Guid("fb670327-720a-4b6a-9f67-9e65a9d8ce08"), "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg", 55000, new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
