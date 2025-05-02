using OsuApi.Core.V2.Users.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Models
{
    public record Score
    {
        [JsonPropertyName("accuracy")]
        public float? Accuracy { get; set; }

        [JsonPropertyName("beatmap_id")]
        public int? BeatmapId { get; set; }

        [JsonPropertyName("best_id")]
        public long? BestId { get; set; }

        [JsonPropertyName("build_id")]
        public int? BuildId { get; set; }

        [JsonPropertyName("classic_total_score")]
        public int? ClassicTotalScore { get; set; }

        [JsonPropertyName("total_score_without_mods")]
        public int? TotalScoreWithoutMods { get; set; }

        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; set; }

        [JsonPropertyName("has_replay")]
        public bool? HasReplay { get; set; }

        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("is_perfect_combo")]
        public bool? IsPerfectCombo { get; set; }

        [JsonPropertyName("legacy_perfect")]
        public bool? LegacyPerfect { get; set; }

        [JsonPropertyName("legacy_score_id")]
        public long? LegacyScoreId { get; set; }

        [JsonPropertyName("legacy_total_score")]
        public int? LegacyTotalScore { get; set; }

        [JsonPropertyName("max_combo")]
        public int? MaxCombo { get; set; }

        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [JsonPropertyName("mode_int")]
        public int? ModeInt { get; set; }

        [JsonPropertyName("maximum_statistics")]
        public ScoreStatistics? MaximumStatistics { get; set; }

        [JsonPropertyName("mods")]
        public Mod[]? Mods { get; set; }

        [JsonPropertyName("passed")]
        public bool? Passed { get; set; }

        [JsonPropertyName("playlist_item_id")]
        public int? PlaylistItemId { get; set; }

        [JsonPropertyName("pp")]
        public float? Pp { get; set; }

        [JsonPropertyName("preserve")]
        public bool? Preserve { get; set; }

        [JsonPropertyName("processed")]
        public bool? Processed { get; set; }

        [JsonPropertyName("rank")]
        public string? Rank { get; set; }

        [JsonPropertyName("ranked")]
        public bool? Ranked { get; set; }

        [JsonPropertyName("room_id")]
        public int? RoomId { get; set; }

        [JsonPropertyName("ruleset_id")]
        public int? RulesetId { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonPropertyName("statistics")]
        public ScoreStatistics? Statistics { get; set; }

        [JsonPropertyName("total_score")]
        public int? TotalScore { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [JsonPropertyName("beatmap")]
        public Beatmap? Beatmap { get; set; }

        [JsonPropertyName("beatmapset")]
        public Beatmapset? Beatmapset { get; set; }

        [JsonPropertyName("weight")]
        public Weight? Weight { get; set; }

        [JsonPropertyName("rank_country")]
        public int? RankCountry { get; set; }

        [JsonPropertyName("rank_global")]
        public int? RankGlobal { get; set; }

        [JsonPropertyName("user")]
        public User? User { get; set; }
    }
}
