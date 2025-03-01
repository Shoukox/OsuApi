using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record UserStatistics
    {
        [JsonPropertyName("count_100")]
        public int? Count100 { get; set; }

        [JsonPropertyName("count_300")]
        public int? Count300 { get; set; }

        [JsonPropertyName("count_50")]
        public int? Count50 { get; set; }

        [JsonPropertyName("count_miss")]
        public int? CountMiss { get; set; }

        /// <summary>
        /// Current country rank according to pp.
        /// </summary>
        [JsonPropertyName("country_rank")]
        public int? CountryRank { get; set; }

        [JsonPropertyName("grade_counts")]
        public GradeCounts? GradeCounts { get; set; }

        /// <summary>
        /// Hit accuracy percentage
        /// </summary>
        [JsonPropertyName("hit_accuracy")]
        public float? HitAccuracy { get; set; }

        /// <summary>
        /// Is actively ranked
        /// </summary>
        [JsonPropertyName("is_ranked")]
        public bool? IsRanked { get; set; }

        [JsonPropertyName("level")]
        public Level? Level { get; set; }

        /// <summary>
        /// Highest maximum combo.
        /// </summary>
        [JsonPropertyName("maximum_combo")]
        public int? MaximumCombo { get; set; }

        /// <summary>
        /// Number of maps played.
        /// </summary>
        [JsonPropertyName("play_count")]
        public int? PlayCount { get; set; }

        /// <summary>
        /// Cumulative time played.
        /// </summary>
        [JsonPropertyName("play_time")]
        public int? PlayTime { get; set; }

        /// <summary>
        /// Performance points
        /// </summary>
        [JsonPropertyName("pp")]
        public float? Pp { get; set; }

        /// <summary>
        /// Experimental (lazer) performance points
        /// </summary>
        [JsonPropertyName("pp_exp")]
        public float? PpExp { get; set; }

        /// <summary>
        /// Current rank according to pp.
        /// </summary>
        [JsonPropertyName("global_rank")]
        public int? GlobalRank { get; set; }

        /// <summary>
        /// Current rank according to experimental (lazer) pp.
        /// </summary>
        [JsonPropertyName("global_rank_exp")]
        public int? GlobalRankExp { get; set; }

        /// <summary>
        /// Current ranked score.
        /// </summary>
        [JsonPropertyName("ranked_score")]
        public long? RankedScore { get; set; }

        /// <summary>
        /// Number of replays watched by other users.
        /// </summary>
        [JsonPropertyName("replays_watched_by_others")]
        public int? ReplaysWatchedByOthers { get; set; }

        /// <summary>
        /// Total number of hits.
        /// </summary>
        [JsonPropertyName("total_hits")]
        public long? TotalHits { get; set; }

        /// <summary>
        /// Total score.
        /// </summary>
        [JsonPropertyName("total_score")]
        public long? TotalScore { get; set; }

        /// <summary>
        /// Difference between current rank and rank 30 days ago, according to pp.
        /// </summary>
        [JsonPropertyName("rank_change_since_30_days")]
        public int? RankChangeSince30Days { get; set; }

        [JsonPropertyName("user")]
        public User? User { get; set; }
    }
}
