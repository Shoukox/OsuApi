using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Scores.Models.HttpIO
{
    public record ScoresQueryParameters
    {
        [QueryParameter("ruleset")]
        public required string Ruleset { get; set; }

        [QueryParameter("cursor_string")]
        public string? CursorString { get; set; }
    }
}
