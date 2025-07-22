using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record UserStatisticsRulesets
    {
        [JsonPropertyName("osu")]
        public UserStatistics? Osu { get; set; }

        [JsonPropertyName("taiko")]
        public UserStatistics? Taiko { get; set; }

        [JsonPropertyName("fruits")]
        public UserStatistics? Fruits { get; set; }

        [JsonPropertyName("mania")]
        public UserStatistics? Mania { get; set; }
    }
}
