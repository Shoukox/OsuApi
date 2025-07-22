using System.Text.Json.Serialization;

namespace OsuApi.V2.Models
{
    public record OsuDifficultyAttributes : DifficultyAttributes
    {
        [JsonPropertyName("aim_difficulty")]
        public float? AimDifficulty { get; set; }

        [JsonPropertyName("approach_rate")]
        public float? ApproachRate { get; set; }

        [JsonPropertyName("flashlight_difficulty")]
        public float? FlashlightDifficulty { get; set; }

        [JsonPropertyName("overall_difficulty")]
        public float? OverallDifficulty { get; set; }

        [JsonPropertyName("slider_factor")]
        public float? SliderFactor { get; set; }

        [JsonPropertyName("speed_difficulty")]
        public float? SpeedDifficulty { get; set; }

        [JsonPropertyName("speed_note_count")]
        public float? SpeedNoteCount { get; set; }
    }
}
