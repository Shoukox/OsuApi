using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
