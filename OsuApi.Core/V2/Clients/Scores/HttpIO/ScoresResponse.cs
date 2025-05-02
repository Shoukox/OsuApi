using OsuApi.Core.V2.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Clients.Scores.HttpIO
{
    public record ScoresResponse
    {
        [JsonPropertyName("scores")]
        public Score[]? Scores { get; set; }

        [JsonPropertyName("cursor_string")]
        public string? CursorString { get; set; }
    }
}
