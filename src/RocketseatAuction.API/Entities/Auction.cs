using System.Security.Cryptography;

namespace RocketseatAuction.API.Entities;

public class Auction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Ends { get; set; }
    public DateTime Starts { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();


}
