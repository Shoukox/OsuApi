using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetUserBeatmapScoresQueryParameters
{
    [QueryParameter("legacy_only")] public string? LegacyOnly { get; set; }

    /// <summary>
    ///     (Deprecated) See <see cref="Models.Ruleset" />
    /// </summary>
    [QueryParameter("mode")]
    public string? Mode { get; set; }

    /// <summary>
    ///     See <see cref="Models.Ruleset" />
    /// </summary>
    [QueryParameter("ruleset")]
    public string? Ruleset { get; set; }
}