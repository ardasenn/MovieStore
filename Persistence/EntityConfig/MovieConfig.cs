using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class MovieConfig : BaseConfig<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.Property(a => a.ReleaseDate).IsRequired();
            builder.Property(a => a.Price).IsRequired();
            builder.Property(a=>a.SalesQuantity).IsRequired();
            builder.Property(a=>a.Id).IsRequired();          
            base.Configure(builder);
        }
    }
}
