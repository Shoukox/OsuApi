using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Scores.Models
{
    public class Mod
    {
        [JsonPropertyName("acronym")]
        public string? Acronym { get; set; }
    }
}
