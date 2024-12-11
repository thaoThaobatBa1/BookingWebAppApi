using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingShop.Model.Model;

namespace BookingShop.Model.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(t => t.TableID);

            builder.Property(t => t.TableNumber)
                   .IsRequired()
                   .HasColumnType("nvarchar(50)");

            builder.Property(t => t.Seats)
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(t => t.Location)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");
        }
    }
}
