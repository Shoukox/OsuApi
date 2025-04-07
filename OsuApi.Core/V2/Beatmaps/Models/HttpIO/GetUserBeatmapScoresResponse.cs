using OsuApi.Core.V2.Scores.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public class GetUserBeatmapScoresResponse
    {
        [JsonPropertyName("scores")]
        public Score[]? Scores { get; set; }
    }
}
