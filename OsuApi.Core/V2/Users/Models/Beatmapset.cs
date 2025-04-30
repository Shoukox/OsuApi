using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record Beatmapset
    {
        [JsonPropertyName("artist")]
        public string? Artist { get; init; }

        [JsonPropertyName("artist_unicode")]
        public string? ArtistUnicode { get; init; }

        [JsonPropertyName("covers")]
        public Covers? Covers { get; init; }

        [JsonPropertyName("creator")]
        public string? Creator { get; init; }

        [JsonPropertyName("favourite_count")]
        public int? FavouriteCount { get; init; }

        [JsonPropertyName("hype")]
        public int? Hype { get; init; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; init; }

        [JsonPropertyName("nsfw")]
        public bool? Nsfw { get; init; }

        [JsonPropertyName("offset")]
        public int? Offset { get; init; }

        [JsonPropertyName("play_count")]
        public int? PlayCount { get; init; }

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; init; }

        [JsonPropertyName("source")]
        public string? Source { get; init; }

        [JsonPropertyName("spotlight")]
        public bool? Spotlight { get; init; }

        [JsonPropertyName("status")]
        public string? Status { get; init; }

        [JsonPropertyName("title")]
        public string? Title { get; init; }

        [JsonPropertyName("title_unicode")]
        public string? TitleUnicode { get; init; }

        [JsonPropertyName("track_id")]
        public int? TrackId { get; init; }

        [JsonPropertyName("user_id")]
        public int? UserId { get; init; }

        [JsonPropertyName("video")]
        public bool? Video { get; init; }

        [JsonPropertyName("nominations_summary")]
        public NominationsSummary? NominationsSummary { get; init; }

        [JsonPropertyName("rating")]
        public float? Rating { get; init; }

        [JsonPropertyName("availability")]
        public Availability? Availability { get; init; }

        [JsonPropertyName("beatmaps")]
        public List<Beatmap>? Beatmaps { get; init; }

        [JsonPropertyName("converts")]
        public List<Beatmap>? Converts { get; init; }

        [JsonPropertyName("current_nominations")]
        public List<object>? CurrentNominations { get; init; }

        [JsonPropertyName("description")]
        public Description? Description { get; init; }

        [JsonPropertyName("genre")]
        public Genre? Genre { get; init; }

        [JsonPropertyName("language")]
        public Language? Language { get; init; }

        [JsonPropertyName("pack_tags")]
        public List<string>? PackTags { get; init; }

        [JsonPropertyName("ratings")]
        public List<int>? Ratings { get; init; }

        [JsonPropertyName("recent_favourites")]
        public List<User>? RecentFavourites { get; init; }

        [JsonPropertyName("related_users")]
        public List<User>? RelatedUsers { get; init; }

        [JsonPropertyName("related_tags")]
        public List<object>? RelatedTags { get; init; }

        [JsonPropertyName("user")]
        public User? User { get; init; }
    }
}
