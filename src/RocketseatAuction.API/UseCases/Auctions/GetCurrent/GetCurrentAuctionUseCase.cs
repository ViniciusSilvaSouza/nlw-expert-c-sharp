using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Excute()
    {
        var respository = new RocketseatAuctionDbContext();

        return respository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault();
    }
}
