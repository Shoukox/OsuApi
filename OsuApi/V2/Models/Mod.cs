using System.Text.Json.Serialization;

namespace OsuApi.V2.Models
{
    public record Mod
    {
        [JsonPropertyName("acronym")]
        public string? Acronym { get; set; }
    }
}
