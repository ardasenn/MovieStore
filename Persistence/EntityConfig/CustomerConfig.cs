using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class CustomerConfig : BaseConfig<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(a=>a.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(a=>a.LastName).HasMaxLength(50).IsRequired();       
            base.Configure(builder);
        }
    }
}
