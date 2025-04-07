using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Scores.Models.HttpIO
{
    public record ScoresResponse
    {
        [JsonPropertyName("scores")]
        public Score[]? Scores { get; set; }

        [JsonPropertyName("cursor_string")]
        public string? CursorString { get; set; }
    }
}
