using OsuApi.Core.V2.Extensions.Converters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
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
