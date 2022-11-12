using AdWeb.DataAccess.EntityConfigurations.AdBoard;
using AdWeb.Infrastructure.Repository;
using MockQueryable.Moq;
using Moq;
using Shouldly;
using Xunit;

namespace AdWeb.Tests
{
    public class AdBoardRepositoryTests
    {
        [Fact]
        public async Task GetAll_AdBoard_Success()
        {
            // arrange

            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var entities = new List<Domain.AdBoard>(new[]
                {
                    new Domain.AdBoard { Id = id1, Ad = new Domain.Ad { AdTitle = "TV" } },
                    new Domain.AdBoard { Id = id2, Ad = new Domain.Ad { AdTitle = "Fridge" } }
                });

            var entitiesMock = entities.BuildMock();

            var repositoryMock = new Mock<IRepository<Domain.AdBoard>>();
            repositoryMock.Setup(x => x.GetAll()).Returns(entitiesMock);

            CancellationToken cancellation = new CancellationToken(false);

            AdBoardRepository repository = new AdBoardRepository(repositoryMock.Object);

            // act

            var result = await repository.GetAllAsync(cancellation);

            // assert

            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);

            foreach (var adBoardDto in result)
            {
                adBoardDto.Id.ShouldNotBe(Guid.Empty);
                adBoardDto.AdTitle.ShouldNotBeNullOrEmpty();
            }
        }
    }
}