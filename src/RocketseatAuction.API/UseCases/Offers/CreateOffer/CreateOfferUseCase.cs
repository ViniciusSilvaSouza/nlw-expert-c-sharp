using Microsoft.Extensions.Logging;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Requests;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;
    public int Excute(int itemId, RequestCreateOfferJson request)
    {

        var user = _loggedUser.User();
        var repository = new RocketseatAuctionDbContext();
        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        repository.Offers.Add(offer);
        repository.SaveChanges();
        return offer.Id;
    }
}
