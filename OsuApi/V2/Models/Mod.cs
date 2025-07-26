using System.Text.Json.Serialization;

namespace OsuApi.V2.Models
{
    public record Mod
    {
        [JsonPropertyName("acronym")]
        public string? Acronym { get; set; }
        
        [JsonPropertyName("settings")]
        public Settings? Settings { get; set; }
    }

    public record Settings
    {
        [JsonPropertyName("speed_change")]
        public double? SpeedChange { get; set; }
    }
}
