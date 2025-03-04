using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Scores.Models
{
    public record ScoreStatistics
    {
        [JsonPropertyName("ok")]
        public int? Ok { get; set; }

        [JsonPropertyName("meh")]
        public int? Meh { get; set; }

        [JsonPropertyName("miss")]
        public int? Miss { get; set; }

        [JsonPropertyName("great")]
        public int? Great { get; set; }

        [JsonPropertyName("legacy_combo_increase")]
        public int? LegacyComboIncrease { get; set; }
    }
}
