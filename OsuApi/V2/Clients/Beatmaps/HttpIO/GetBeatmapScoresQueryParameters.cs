using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapScoresQueryParameters
    {
        [QueryParameter("legacy_only")]
        public string? LegacyOnly { get; set; }

        /// <summary>
        /// See <see cref="Models.Ruleset"/>
        /// </summary>
        [QueryParameter("mode")]
        public string? Mode { get; set; }

        [QueryParameter("mods")]
        public string? Mods { get; set; }

        [QueryParameter("type")]
        public string? Type { get; set; }
    }
}
