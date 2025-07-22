using System.Text.Json.Serialization;
using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Beatmaps.HttpIO
{
    public record GetBeatmapAttributesResponse
    {
        [JsonPropertyName("attributes")]
        public OsuDifficultyAttributes? DifficultyAttributes { get; set; }
    }
}
