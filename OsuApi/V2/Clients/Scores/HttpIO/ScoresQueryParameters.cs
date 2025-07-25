﻿using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Scores.HttpIO
{
    public record ScoresQueryParameters
    {
        [QueryParameter("ruleset")]
        public required string Ruleset { get; set; }

        [QueryParameter("cursor_string")]
        public string? CursorString { get; set; }
    }
}
