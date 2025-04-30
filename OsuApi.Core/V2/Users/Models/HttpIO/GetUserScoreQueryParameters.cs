using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserScoreQueryParameters
    {
        [QueryParameter("legacy_only")]
        public string? LegacyOnly { get; set; }

        /// <summary>
        /// 0 or 1
        /// </summary>
        [QueryParameter("include_fails")]
        public int? IncludeFails { get; set; }

        /// <summary>
        /// See <see cref="Scores.Models.Ruleset"/>
        /// </summary>
        [QueryParameter("mode")]
        public string? Mode { get; set; }

        [QueryParameter("limit")]
        public int? Limit { get; set; }

        [QueryParameter("offset")]
        public int? Offset { get; set; }
    }
}
