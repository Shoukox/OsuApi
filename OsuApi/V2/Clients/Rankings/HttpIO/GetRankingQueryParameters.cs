using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Rankings.HttpIO;

public record GetRankingQueryParameters
{
    /// <summary>
    ///     Filter ranking by country code. Only available for type of global.
    /// </summary>
    [QueryParameter("country")]
    public string? Country { get; set; }

    [QueryParameter("cursor[page]")] public int? CursorPage { get; set; }

    /// <summary>
    ///     See <see cref="Filter" />
    /// </summary>
    [QueryParameter("filter")]
    public string? Filter { get; set; }

    /// <summary>
    ///     The id of the spotlight if type is charts. Ranking for latest spotlight will be returned if not specified.
    /// </summary>
    [QueryParameter("spotlight")]
    public string? Spotlight { get; set; }

    /// <summary>
    ///     Filter ranking to specified mode variant. For ruleset of mania, it's either 4k or 7k. Only available for type of
    ///     global.
    /// </summary>
    [QueryParameter("variant")]
    public string? Variant { get; set; }
}