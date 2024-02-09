using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Requests;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    private readonly IOfferRepository _offerRepository;
    public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository offerRepository)
    {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
    }
    public int Excute(int itemId, RequestCreateOfferJson request)
    {

        var user = _loggedUser.User();
        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        _offerRepository.Add(offer);
        return offer.Id;
    }
}
