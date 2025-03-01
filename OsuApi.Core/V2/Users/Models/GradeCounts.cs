using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record GradeCounts
    {
        /// <summary>
        /// Number of A ranked scores.
        /// </summary>
        [JsonPropertyName("a")]
        public int? A { get; set; }

        /// <summary>
        /// Number of S ranked scores.
        /// </summary>
        [JsonPropertyName("s")]
        public int? S { get; set; }

        /// <summary>
        /// Number of Silver S ranked scores.
        /// </summary>
        [JsonPropertyName("sh")]
        public int? SH { get; set; }

        /// <summary>
        /// Number of SS ranked scores.
        /// </summary>
        [JsonPropertyName("ss")]
        public int? SS { get; set; }

        /// <summary>
        /// Number of Silver SS ranked scores.
        /// </summary>
        [JsonPropertyName("ssh")]
        public int? SSH { get; set; }
    }
}
