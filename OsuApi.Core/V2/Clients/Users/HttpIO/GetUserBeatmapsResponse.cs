using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetUserBeatmapsResponse
    {
        public BeatmapPlaycount[]? BeatmapPlaycounts { get; set; }
        public BeatmapsetExtended[]? BeatmapsetExtendeds { get; set; }
    }
}
