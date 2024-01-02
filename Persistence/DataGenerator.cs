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
                    Id = Guid.NewGuid().ToString(),
                    Email = "ardasen.96@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ARDASEN.96@GMAIL.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw==",
                    CreationDate = DateTime.UtcNow
                });
            var genre = new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Komedi",
                CreationDate = DateTime.UtcNow
            };


            var actor = new Actor()
            {
                Id = Guid.NewGuid(),
                FirstName = "Cem",
                LastName = "Yılmaz",
                IsDirector = true,
                CreationDate = DateTime.UtcNow
            };
            var movie = new Movie()
            {
                Name = "Arog",
                DirectorId = actor.Id.ToString(),
                Price = 28.00M,
                Imdb = 7.3,
                Id = Guid.NewGuid(),
                SalesQuantity = 0,
                CreationDate = DateTime.UtcNow
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
        public static void AddFakeData(MovieDbContext context)
        {

            var user = new Customer()
            {
                UserName = "arda",
                FirstName = "Arda",
                LastName = "Şen",
                Id = "a575cfe7-022d-40e9-86b3-2f635c40c969",
                Email = "ardasen.96@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "ARDASEN.96@GMAIL.COM",
                NormalizedUserName = "ADMIN",
                PasswordHash = "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw=="

            };

            var genre = new Genre()
            {
                Id = Guid.Parse("d2bd7c60-b4d8-407b-8b9f-d7a85e927ec2"),
                Name = "Komedi",
            };


            var actor = new Actor()
            {
                Id = Guid.Parse("3b6cbbe2-27df-4a87-985a-83e98d63fb42"),
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
                Id = Guid.Parse("f4e6b829-cc89-4a9e-9c8b-94b442028a32"),
                SalesQuantity = 0,
            };


            context.Genres.Add(genre);
            context.Actors.Add(actor);
            context.Movies.Add(movie);
            context.Customers.Add(user);
        }
    }
}
