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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryID);

            builder.Property(c => c.CategoryName)
                   .IsRequired() 
                   .HasMaxLength(100) 
                   .HasColumnType("nvarchar(100)");

            builder.Property(c => c.CategoryDescription)
                   .HasMaxLength(500)
                   .HasColumnType("nvarchar(500)");

        }
    }
}
