using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class OrderConfig : BaseConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(a => a.Id).IsRequired();         
            base.Configure(builder);
        }
    }
}
