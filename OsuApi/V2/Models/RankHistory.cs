using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record RankHistory
    {
        /// <summary>
        /// See <see cref="V2.Models.Ruleset"/>
        /// </summary>
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [JsonPropertyName("data")]
        public int[]? Data { get; set; }
    }
}
