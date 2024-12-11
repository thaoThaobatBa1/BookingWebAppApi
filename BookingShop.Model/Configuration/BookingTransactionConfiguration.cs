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
    public class BookingTransactionConfiguration : IEntityTypeConfiguration<BookingTransaction>
    {

        public void Configure(EntityTypeBuilder<BookingTransaction> builder)
        {
            builder.HasKey(a => a.TransactionID);

            builder.Property(bt => bt.TransactionDate)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(bt => bt.TransactionAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(bt => bt.Payments)
                   .WithMany(p => p.BookingTransactions)
                   .HasForeignKey(bt => bt.PaymentID);

        }
    }
}
