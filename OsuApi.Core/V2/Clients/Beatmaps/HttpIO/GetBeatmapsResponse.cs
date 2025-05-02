using OsuApi.Core.V2.Users.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapsResponse
    {
        [JsonPropertyName("beatmaps")]
        public BeatmapExtended[]? BeatmapExtendeds { get; set; }
    }
}
