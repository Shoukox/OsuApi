using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetUserBeatmapScoreQueryParameters
{
    [QueryParameter("legacy_only")] public string? LegacyOnly { get; set; }

    /// <summary>
    ///     See <see cref="Models.Ruleset" />
    /// </summary>
    [QueryParameter("mode")]
    public string? Mode { get; set; }

    [QueryParameter("mods")] public string? Mods { get; set; }
}