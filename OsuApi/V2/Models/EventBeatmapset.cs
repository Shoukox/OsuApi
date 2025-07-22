using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record EventBeatmapset : Beatmapset
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
