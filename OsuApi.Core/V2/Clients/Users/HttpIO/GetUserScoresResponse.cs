using OsuApi.Core.V2.Models;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetUserScoresResponse
    {
        public required Score[] Scores { get; set; }
    }
}
