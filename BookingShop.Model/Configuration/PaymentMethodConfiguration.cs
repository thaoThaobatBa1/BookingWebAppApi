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
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.PaymentMethodID);

            builder.Property(pm => pm.PaymentMethodID)
                   .IsRequired();

            builder.Property(pm => pm.MethodName)
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");

        }
    }
}
