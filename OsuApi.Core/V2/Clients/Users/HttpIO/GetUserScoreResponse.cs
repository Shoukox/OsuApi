using OsuApi.Core.V2.Models;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetUserScoreResponse
    {
        public required Score[] Scores { get; set; }
    }
}
