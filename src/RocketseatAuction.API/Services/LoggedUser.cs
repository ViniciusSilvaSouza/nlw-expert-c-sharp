using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RocketseatAuction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }
    public User User()
    {
        var respository = new RocketseatAuctionDbContext();
        var token = TokenOnRequest();
        var email = FromBase64String(token);
        return respository.Users.First(x => x.Email.Equals(email));
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
