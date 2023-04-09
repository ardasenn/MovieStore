using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class ActorConfig : BaseConfig<Actor>
    {
        public override void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
