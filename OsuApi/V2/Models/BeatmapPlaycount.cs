using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record BeatmapPlaycount
    {
        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("beatmap_id")]
        [NotNull]
        public int? BeatmapId { get; set; }

        [JsonPropertyName("beatmap")]
        public Beatmap? Beatmap { get; set; }

        [JsonPropertyName("beatmapset")]
        public Beatmapset? Beatmapset { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }
    }
}
