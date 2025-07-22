using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO
{
    public record LookupBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
