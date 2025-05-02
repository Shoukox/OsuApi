using OsuApi.Core.V2.Extensions.Converters;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record UserExtend : User
    {
        /// <summary>
        /// url of profile cover. Deprecated, use cover.url instead.
        /// </summary>
        [JsonPropertyName("cover_url")]
        public string? CoverUrl { get; set; }

        [JsonPropertyName("discord")]
        public string? Discord { get; set; }

        /// <summary>
        /// Whether or not the user has a current or past osu!supporter tag.
        /// </summary>
        [JsonPropertyName("has_supported")]
        public bool? HasSupported { get; set; }

        [JsonPropertyName("interests")]
        public string? Interests { get; set; }

        [JsonPropertyName("join_date")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public Timestamp? JoinDate { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        /// <summary>
        /// maximum number of users allowed to be blocked
        /// </summary>
        [JsonPropertyName("max_blocks")]
        public int? MaxBlocks { get; set; }

        /// <summary>
        /// maximum number of friends allowed to be added
        /// </summary>
        [JsonPropertyName("max_friends")]
        public int? MaxFriends { get; set; }

        [JsonPropertyName("occupation")]
        public string? Occupation { get; set; }

        /// <summary>
        /// See <see cref="V2.Models.Ruleset">Ruleset</see>
        /// </summary>
        [JsonPropertyName("playmode")]
        public string? Playmode { get; set; }

        /// <summary>
        /// Device choices of the user.
        /// </summary>
        [JsonPropertyName("playstyle")]
        public string[]? Playstyle { get; set; }

        /// <summary>
        /// Number of forum posts
        /// </summary>
        [JsonPropertyName("post_count")]
        public int? PostCount { get; set; }

        /// <summary>
        /// Custom colour hue in HSL degrees (0–359).
        /// </summary>
        [JsonPropertyName("profile_hue")]
        public int? ProfileHue { get; set; }

        /// <summary>
        /// Ordered array of sections in user profile page
        /// </summary>
        [JsonPropertyName("profile_order")]
        public string[]? ProfileOrder { get; set; }

        /// <summary>
        /// User-specific title
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("title_url")]
        public string? TitleUrl { get; set; }

        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }

        [JsonPropertyName("website")]
        public string? Website { get; set; }
    }
}
