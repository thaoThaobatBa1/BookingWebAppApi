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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100) 
                   .HasColumnType("nvarchar(100)"); 

            builder.Property(c => c.PhoneNumber)
                   .HasMaxLength(15) 
                   .HasColumnType("nvarchar(15)");  
        }
    }
}
