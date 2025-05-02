using OsuApi.Core.V2.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapAttributesResponse
    {
        [JsonPropertyName("attributes")]
        public OsuDifficultyAttributes? DifficultyAttributes { get; set; }
    }
}
