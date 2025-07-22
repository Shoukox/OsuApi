using System.Text.Json.Serialization;
using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Scores.HttpIO
{
    public record ScoresResponse
    {
        [JsonPropertyName("scores")]
        public Score[]? Scores { get; set; }

        [JsonPropertyName("cursor_string")]
        public string? CursorString { get; set; }
    }
}
