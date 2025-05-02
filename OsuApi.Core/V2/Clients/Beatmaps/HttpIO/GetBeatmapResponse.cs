using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
