using OsuApi.Core.V2.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record GetUserBeatmapScoresResponse
    {
        [JsonPropertyName("scores")]
        public Score[]? Scores { get; set; }
    }
}
