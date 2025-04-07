using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record GetUserBeatmapScoresQueryParameters
    {
        [QueryParameter("legacy_only")]
        public string? LegacyOnly { get; set; }

        /// <summary>
        /// (Deprecated) See <see cref="Scores.Models.Ruleset"/>
        /// </summary>
        [QueryParameter("mode")]
        public string? Mode { get; set; }

        /// <summary>
        /// See <see cref="Scores.Models.Ruleset"/>
        /// </summary>
        [QueryParameter("ruleset")]
        public string? Ruleset { get; set; }
    }
}
