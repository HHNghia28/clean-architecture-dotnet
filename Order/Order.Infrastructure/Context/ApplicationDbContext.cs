using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Order.Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid OrderId = Guid.NewGuid();

            modelBuilder.Entity<Order.Domain.Entities.Order>()
                .HasData(
                    new Domain.Entities.Order()
                    {
                        Id = OrderId,
                        FullName = "Huỳnh Hữu Nghĩa",
                        Phone = "0832474699",
                        Address = "Cần Thơ",
                        Discount = 0,
                        ShippingFee = 32000,
                        VoucherCode = "NGHIAHH",
                        VoucherName = "Voucher 28/08",
                        VoucherValue = 24,
                        Note = "Giao hàng nhanh",
                        Status = Domain.Enums.OrderStatus.PENDING,
                        TotalPrice = 289814,
                        CreatedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                        LastModifiedBy = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f207"),
                    }
                );

            modelBuilder.Entity<OrderDetail>()
                .HasData(
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "PhinDi Cassia",
                        Description = "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                        Category = "Coffee",
                        Price = 55000,
                        Discount = 0,
                        Quantity = 2,
                        OrderId = OrderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201")
                    },
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "Phindi Hạt Dẻ Cười",
                        Description = "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                        Category = "Coffee",
                        Price = 65000,
                        Discount = 5,
                        Quantity = 2,
                        OrderId = OrderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202")
                    },
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                        Description = "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                        Category = "Other",
                        Price = 109000,
                        Discount = 3,
                        Quantity = 1,
                        OrderId = OrderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209")
                    }
                );
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is Domain.Entities.Order &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Domain.Entities.Order order)
                {
                    if (entry.State == EntityState.Added)
                    {
                        order.CreatedAt = DateTime.UtcNow;
                    }
                    order.LastModifiedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is Domain.Entities.Order &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Domain.Entities.Order order)
                {
                    if (entry.State == EntityState.Added)
                    {
                        order.CreatedAt = DateTime.UtcNow;
                    }
                    order.LastModifiedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
