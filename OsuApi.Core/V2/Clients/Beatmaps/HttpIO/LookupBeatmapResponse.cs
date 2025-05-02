using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record LookupBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
