using OsuApi.Core.V2.Scores.Models;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserScoreResponse
    {
        public required Score[] Scores { get; set; }
    }
}
