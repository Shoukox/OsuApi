using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Users.HttpIO;

public record GetUserRecentActivityResponse
{
    public required Event[] Events { get; set; }
}