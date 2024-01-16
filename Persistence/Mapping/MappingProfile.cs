using Application.DTOs.ActorDTOs;
using Application.DTOs.CommentDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.GenreDTOs;
using Application.DTOs.MovieDTOs;
using Application.VMs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<CreateActorDTO, Actor>();
            CreateMap<UpdateActorDTO, Actor>();
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>();
            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<UpdateCommentDTO, Comment>();
            CreateMap<Actor, ActorVM>();
            CreateMap<Genre, GenreVM>();
            CreateMap<Movie, UserMovie>();
            CreateMap<Movie, MovieVM>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new GenreVM
            {
                Id = g.Id,
                Name = g.Name
            })))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(a => new ActorSummaryVM { Id = a.Id, FirstName = a.FirstName, LastName = a.LastName })))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Where(a=>a.Status!=Domain.Enums.Status.Pasive).Select(c => new CommentVM { Id = c.Id, Rate = c.Rate, Text = c.Text, CreationDate = c.CreationDate, UpdateDate = c.UpdateDate })));
            CreateMap<Order, OrderVM>().ForMember(dest=>dest.MovieList,opt=> opt.MapFrom(src=>src.MovieList.Select(a=>new UserMovie { Id=a.Id,ReleaseDate=a.ReleaseDate,DirectorId=a.DirectorId,Name=a.Name,Imdb=a.Imdb,Price=a.Price})));
        }
    }
}
