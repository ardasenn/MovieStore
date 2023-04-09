using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class CommentConfig : BaseConfig<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.Text).HasMaxLength(10000).IsRequired();
            builder.Property(a => a.Rate).IsRequired();
            base.Configure(builder);
        }
    }
}
