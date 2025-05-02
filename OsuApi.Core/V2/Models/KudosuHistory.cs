using OsuApi.Core.V2.Extensions.Converters;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record KudosuHistory
    {
        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        /// <summary>
        /// One of give, vote.give, reset, vote.reset, revoke, or vote.revoke.
        /// </summary>
        [JsonPropertyName("action")]
        public string? Action { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// Object type which the exchange happened on (forum_post, etc).
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Timestamp string in ISO 8601 format.
        /// <example>
        /// <code>2020-01-01T00:00:00+00:00</code>
        /// </example>
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? CreatedAt { get; set; }

        /// <summary>
        /// Simple detail of the user who started the exchange.
        /// </summary>
        [JsonPropertyName("giver")]
        public Giver? Giver { get; set; }

        /// <summary>
        /// Simple detail of the object for display.
        /// </summary>
        [JsonPropertyName("post")]
        public Post? Post { get; set; }
    }
}
