using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO;

public record GetBeatmapsQueryParameters
{
    [QueryParameter("ids[]")] public int[]? BeatmapIds { get; set; }
}