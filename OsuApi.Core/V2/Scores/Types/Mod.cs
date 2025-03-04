using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Scores.Models
{
    public record Mod
    {
        [JsonPropertyName("acronym")]
        public string? Acronym { get; set; }
    }
}
