using System.Text.Json.Serialization;

namespace OsuApi.V2.Models
{
    public record BeatmapScores
    {
        /// <summary>
        /// The score of the current user. This is not returned if the current user does not have a score. Note: will be moved to user_score in the future
        /// </summary>
        [JsonPropertyName("userScore")]
        public BeatmapUserScore? BeatmapUserScore { get; set; }

        /// <summary>
        /// The list of top scores for the beatmap in descending order.
        /// </summary>
        [JsonPropertyName("scores")]
        public Score[]? Score { get; set; }
    }
}
