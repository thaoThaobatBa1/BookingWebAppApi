using BookingShop.Model.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailID);

            builder.Property(od => od.Quantity)
                   .IsRequired();

            builder.Property(od => od.Price)
                   .HasColumnType("decimal(18, 2)") 
                   .IsRequired();

            builder.HasOne(od => od.MenuItem)
                   .WithMany(mi => mi.OrderDetails)
                   .HasForeignKey(od => od.MenuItemID);

            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderID);

        }
    }
}
