

using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auction.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Sucess()
    {
        ///ARRANGE


        var entity = new Faker<RocketseatAuction.API.Entities.Auction>()
            .RuleFor(x => x.Id, f => f.Random.Number(1, 700)).
            RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Starts, f => f.Date.Past())
            .RuleFor(x => x.Starts, f => f.Date.Future())
            .RuleFor(x => x.Items, (f, auction) => new List<Item>
            {
                new Item {
                   Id = f.Random.Number(1, 700),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50,1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();


        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //ACT
        var auction = useCase.Excute();

        //ASSERT
        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
        auction.Starts.Should().Be(entity.Starts);
        auction.Ends.Should().Be(entity.Ends);  
    }
}
