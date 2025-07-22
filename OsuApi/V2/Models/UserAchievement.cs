using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using OsuApi.V2.Extensions.Converters;

namespace OsuApi.V2.Users.Models
{
    public class UserAchievement
    {
        [JsonPropertyName("achieved_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? AchievedAt { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("achievement_id")]
        [NotNull]
        public int? AchievementId { get; set; }
    }
}
