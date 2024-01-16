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
            List<Genre> genreList = new List<Genre>
{
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Aksiyon",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Drama",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Bilim Kurgu",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Romantik",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Korku",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Fantastik",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Komedi",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Gerilim",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Belgesel",
        CreationDate = DateTime.UtcNow
    },
    new Genre
    {
        Id = Guid.NewGuid(),
        Name = "Macera",
        CreationDate = DateTime.UtcNow
    }
};

            var actors = new List<Actor>
{
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Cem",
        LastName = "Yılmaz",
        IsDirector = true,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Demet",
        LastName = "Evgar",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Rasim",
        LastName = "Öztekin",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Zafer",
        LastName = "Algöz",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Ozan",
        LastName = "Güven",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Cengiz",
        LastName = "Bozkurt",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "İlker",
        LastName = "Kaleli",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Melisa",
        LastName = "Aslı Pamuk",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Ahmet",
        LastName = "Kural",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    },
    new Actor
    {
        Id = Guid.NewGuid(),
        FirstName = "Rasim",
        LastName = "Öztekin",
        IsDirector = false,
        CreationDate = DateTime.UtcNow
    }
};

            List<Movie> cemYilmazMovies = new List<Movie>
{
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Arog",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 28.00M,
        Imdb = 7.3,
        SalesQuantity = 10,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "G.O.R.A",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 25.00M,
        Imdb = 7.8,
        SalesQuantity = 15,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Yahşi Batı",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 30.00M,
        Imdb = 6.9,
        SalesQuantity = 8,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "CM101MMXI Fundamentals",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 32.50M,
        Imdb = 8.1,
        SalesQuantity = 20,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Pek Yakında",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 27.50M,
        Imdb = 6.3,
        SalesQuantity = 12,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Arif v 216",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 35.00M,
        Imdb = 6.7,
        SalesQuantity = 18,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Gora + Arog",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 40.00M,
        Imdb = 7.5,
        SalesQuantity = 25,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Ali Baba ve 7 Cüceler",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 33.50M,
        Imdb = 6.2,
        SalesQuantity = 14,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Cehennem Melekleri 2",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 29.00M,
        Imdb = 6.7,
        SalesQuantity = 22,
        CreationDate = DateTime.UtcNow
    },
    new Movie
    {
        Id = Guid.NewGuid(),
        Name = "Fasulye",
        DirectorId = actors.FirstOrDefault(a => a.FirstName == "Cem")?.Id.ToString(),
        Price = 26.50M,
        Imdb = 6.5,
        SalesQuantity = 16,
        CreationDate = DateTime.UtcNow
    }
};

            // cemYilmazMovies'i kullanabilirsin

            modelBuilder.Entity<Genre>().HasData(
                genreList);
            modelBuilder.Entity<Actor>().HasData(
               actors);
            modelBuilder.Entity<Movie>().HasData(
               cemYilmazMovies);

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
