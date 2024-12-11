using BookingShop.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderID);

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.TotalPrice)
                   .HasColumnType("decimal(18, 2)") 
                   .IsRequired();

            builder.Property(o => o.PaymentStatus)
                   .IsRequired();
            
        }
    }
}
