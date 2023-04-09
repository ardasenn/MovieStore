using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public  class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new MovieDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>()))
            {
                context.Customers.Add(new()
                {
                    UserName="admin",
                    FirstName="admin",
                    Id= Guid.NewGuid(),
                    Email="ardasen.96@gmail.com",
                    EmailConfirmed=true,
                    NormalizedEmail = "ARDASEN.96@GMAIL.COM",
                    NormalizedUserName="ADMIN",
                    PasswordHash= "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw=="
                });
                context.SaveChanges();
            }
        }
    }
}
