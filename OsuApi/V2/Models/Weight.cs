using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Weight
    {
        [JsonPropertyName("percentage")]
        public double? Percentage { get; set; }

        [JsonPropertyName("pp")]
        public double? Pp { get; set; }
    }
}
