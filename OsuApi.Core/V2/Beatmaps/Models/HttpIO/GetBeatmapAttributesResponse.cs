using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record GetBeatmapAttributesResponse
    {
        [JsonPropertyName("attributes")]
        public OsuDifficultyAttributes? DifficultyAttributes { get; set; }
    }
}
