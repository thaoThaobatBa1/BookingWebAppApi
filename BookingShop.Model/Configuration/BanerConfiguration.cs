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
    public class BanerConfiguration : IEntityTypeConfiguration<Baner>
    {
        public void Configure(EntityTypeBuilder<Baner> builder)
        {
            builder.HasKey(a => a.BanerId);
        }
    }
}
