using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Models
{
    public record BeatmapUserScore
    {
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        [JsonPropertyName("score")]
        public Score? Score { get; set; }
    }
}
