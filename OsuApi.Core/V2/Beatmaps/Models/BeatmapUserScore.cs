using OsuApi.Core.V2.Scores.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Beatmaps.Models
{
    public record BeatmapUserScore
    {
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        [JsonPropertyName("score")]
        public Score? Score { get; set; }
    }
}
