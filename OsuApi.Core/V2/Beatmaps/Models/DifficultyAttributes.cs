using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Beatmaps.Models
{
    public record DifficultyAttributes
    {
        [JsonPropertyName("max_combo")]
        public int? MaxCombo { get; set; }

        [JsonPropertyName("star_rating")]
        public float? StarRating { get; set; }
    }
}