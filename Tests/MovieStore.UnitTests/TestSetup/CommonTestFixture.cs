using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Repositories.IActorRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Persistence.ConcreteServices.ActorService;
using Persistence.Context;
using Persistence.Mapping;

namespace MovieStore.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IActorWriteRepository WriteRepository { get; set; }
        public IActorReadRepository ReadRepository { get; set; }
        public ActorService ActorService { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>().UseInMemoryDatabase("MovieStoreTestDB").Options;
            Context = new MovieDbContext(options);
            Context.Database.EnsureCreated();//emin oluyoruz
            DataGenerator.AddFakeData(Context);
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
            // WriteRepository ve ReadRepository için Mock nesneleri oluþturuyoruz
            var writeRepositoryMock = new Mock<IActorWriteRepository>();
            var readRepositoryMock = new Mock<IActorReadRepository>();


            // AddAsync metodu için Mock implementation
            writeRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Actor>())).ReturnsAsync(true);
            // RemoveAsync metodu için Mock implementation
            writeRepositoryMock.Setup(r => r.RemoveAsync(It.IsAny<string>())).ReturnsAsync(true);
            //Update için
            writeRepositoryMock.Setup(r => r.Update(It.IsAny<Actor>())).Returns(true);


            // GetAll metodu için Mock implementation
            readRepositoryMock.Setup(r => r.GetAll()).Returns(new List<Actor>().AsQueryable());
            // GetWhere metodu için Mock implementation
            readRepositoryMock.Setup(r => r.GetWhere(It.IsAny<Expression<Func<Actor, bool>>>())).Returns(new List<Actor>().AsQueryable());
            // vb.
            writeRepositoryMock.Setup(r => r.SaveAsync()).ReturnsAsync(1);
            WriteRepository = writeRepositoryMock.Object;
            ReadRepository = readRepositoryMock.Object;

            ActorService = new ActorService(WriteRepository, ReadRepository, Mapper);
        }
    }
}