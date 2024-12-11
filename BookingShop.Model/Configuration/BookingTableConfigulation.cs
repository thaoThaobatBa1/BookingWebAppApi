using BookingShop.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingShop.Model.Configuration
{
    public class BookingTableConfigulation : IEntityTypeConfiguration<BookingTable>
    {
        public void Configure(EntityTypeBuilder<BookingTable> builder)
        {
            builder.HasKey(a => a.BookingTableId);

            builder.HasOne(a => a.Table).WithMany(a => a.BookingTables).HasForeignKey(a => a.BookingTableId);
            builder.HasOne(a => a.Booking).WithMany(a => a.BookingTables).HasForeignKey(a => a.BookingTableId);


        }
    }
}
