using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Users.HttpIO;

public record GetUserScoresResponse
{
    public required Score[] Scores { get; set; }
}