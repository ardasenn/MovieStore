using Application.Repositories.IActorRepositories;
using Application.Repositories.ICommentRepositories;

using Application.Repositories.IGenreRepositories;
using Application.Repositories.IMovieRepositories;
using Application.Repositories.IOrderRepositories;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ConcreteServices.CustomerService;
using Persistence.ConcreteServices.GenreService;
using Persistence.Context;
using Persistence.Mapping;
using Persistence.Repositories.ActorRepository;
using Persistence.Repositories.CommentRepository;

using Persistence.Repositories.GenreRepository;
using Persistence.Repositories.MovieRepository;
using Persistence.Repositories.OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Persistence.ConcreteServices.ActorService;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MovieDb")));
            services.AddIdentity<Customer, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<MovieDbContext>()
            .AddDefaultTokenProviders();

            //Repositories
            services.AddScoped<IActorReadRepository, ActorReadRepository>();
            services.AddScoped<IActorWriteRepository, ActorWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<IGenreReadRepository, GenreReadRepository>();
            services.AddScoped<IGenreWriteRepository, GenreWriteRepository>();
            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //Services
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IGenreService, GenreService>();
            //Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
