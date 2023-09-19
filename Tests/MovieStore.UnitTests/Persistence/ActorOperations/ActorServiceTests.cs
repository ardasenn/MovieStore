using Application.DTOs.ActorDTOs;
using Application.Repositories.IActorRepositories;
using Application.Utilities.Response;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using MovieStore.UnitTests.TestSetup;
using Persistence.ConcreteServices.ActorService;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.UnitTests.Persistence.ActorOperations
{
    public class ActorServiceTests : IClassFixture<CommonTestFixture>
    {
        private MovieDbContext context;
        private IMapper mapper;
        private IActorWriteRepository WriteRepository;
        private IActorReadRepository ReadRepository;
        private ActorService ActorService;
        public ActorServiceTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
            WriteRepository = testFixture.WriteRepository;
            ReadRepository = testFixture.ReadRepository;
            ActorService = testFixture.ActorService;
        }

        public void WhenExistActorNamesGiven_Message_Exist()
        {
            // Arrange
            var actor = new CreateActorDTO()
            {
                FirstName = "Cem",
                LastName = "Yýlmaz",
                IsDirector = true,
            };

            // Aktör isimlerinin sistemde zaten olduðunu varsayalým


            // Act
            //FluentActions.Invoking(async () => await ActorService.CreateActor(actor))
            // .Should().NotThrowAsync().Result.Should()
        }
    }
}