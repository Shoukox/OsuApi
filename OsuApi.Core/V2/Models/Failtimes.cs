using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Failtimes
    {
        [JsonPropertyName("exit")]
        public int[]? Exit { get; set; }

        [JsonPropertyName("fail")]
        public int[]? Fail { get; set; }
    }
}
