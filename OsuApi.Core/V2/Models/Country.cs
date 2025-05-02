using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Country
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
