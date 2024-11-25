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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder.HasKey(p => p.PaymentID);

            builder.Property(p => p.PaymentDate)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne(p => p.Order)
                   .WithMany(o => o.Payments)  
                   .HasForeignKey(p => p.OrderID);

            builder.HasOne(p => p.PaymentMethod)
                   .WithMany(pm => pm.Payments)
                   .HasForeignKey(p => p.PaymentMethodID);
        }
    }
}
