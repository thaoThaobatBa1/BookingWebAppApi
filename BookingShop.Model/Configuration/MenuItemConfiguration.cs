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
  
        public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
        {
            public void Configure(EntityTypeBuilder<MenuItem> builder)
            {
                builder.HasKey(mi => mi.MenuItemID);

                builder.Property(mi => mi.ItemName)
                       .IsRequired()
                       .HasMaxLength(100) 
                       .HasColumnType("nvarchar(100)");

                builder.Property(mi => mi.Description)
                       .HasMaxLength(500) 
                       .HasColumnType("nvarchar(500)");

                builder.Property(mi => mi.Price)
                       .HasColumnType("decimal(18, 2)")  
                       .IsRequired();

                builder.Property(mi => mi.Available)
                       .IsRequired();

                builder.HasOne(mi => mi.Menu)
                   .WithMany(m => m.MenuItems)
                   .HasForeignKey(mi => mi.MenuID);

                builder.HasOne(mi => mi.Category)
                   .WithMany(c => c.MenuItems)
                   .HasForeignKey(mi => mi.CategoryID);
            }
        }
    }
