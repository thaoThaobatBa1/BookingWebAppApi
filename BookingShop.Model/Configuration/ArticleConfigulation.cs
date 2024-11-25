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
    public class ArticleConfigulation : IEntityTypeConfiguration<article>
    {
        public void Configure(EntityTypeBuilder<article> builder)
        {
            builder.HasKey(a => a.articleId);


         
        }
    }
}
