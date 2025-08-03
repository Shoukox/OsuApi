using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record LookupBeatmapQueryParameters
{
    /// <summary>
    ///     A beatmap checksum.
    /// </summary>
    [QueryParameter("checksum")]
    public string? Checksum { get; set; }

    /// <summary>
    ///     A filename to lookup.
    /// </summary>
    [QueryParameter("filename")]
    public string? Filename { get; set; }

    /// <summary>
    ///     A beatmap ID to lookup.
    /// </summary>
    [QueryParameter("id")]
    public long? Id { get; set; }
}