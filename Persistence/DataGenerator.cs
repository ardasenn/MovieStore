using Domain.Entities;
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
    public class DataGenerator
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    Id = Guid.NewGuid(),
                    Email = "ardasen.96@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ARDASEN.96@GMAIL.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw=="
                });
            var genre = new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Komedi",
            };


            var actor = new Actor()
            {
                Id = Guid.NewGuid(),
                FirstName = "Cem",
                LastName = "Yılmaz",
                IsDirector = true,
            };
            var movie = new Movie()
            {
                Name = "Arog",
                DirectorId = actor.Id.ToString(),
                Price = 28.00M,
                Imdb = 7.3,
                Id = Guid.NewGuid(),
                SalesQuantity = 0,
            };
            modelBuilder.Entity<Genre>().HasData(
                genre);
            modelBuilder.Entity<Actor>().HasData(
               actor);
            modelBuilder.Entity<Movie>().HasData(
               movie);

            //Aktore ve movie
            modelBuilder
           .Entity<Actor>()
           .HasMany(p => p.Movies)
           .WithMany(p => p.Actors)
           .UsingEntity(j => j.HasData(new
           {
               ActorsId = actor.Id,
               MoviesId = movie.Id
           }));
            //Movie ve Genre
            modelBuilder
           .Entity<Movie>()
           .HasMany(p => p.Genres)
           .WithMany(p => p.Movies)
           .UsingEntity(j => j.HasData(new
           {
               MoviesId = movie.Id,
               GenresId = genre.Id
           }));
        }
    }
}
