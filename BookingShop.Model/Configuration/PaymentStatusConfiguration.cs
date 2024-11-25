using BookingShop.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Configuration
{
    public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasKey(a => a.PaymentStatusID);
            builder.HasMany(ps => ps.Orders)
                    .WithOne(o => o.PaymentStatus)
                    .HasForeignKey(o => o.PaymentStatusId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
