using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record Beatmapset
{
    [JsonPropertyName("artist")] public string? Artist { get; set; }

    [JsonPropertyName("artist_unicode")] public string? ArtistUnicode { get; set; }

    [JsonPropertyName("covers")] public Covers? Covers { get; set; }

    [JsonPropertyName("creator")] public string? Creator { get; set; }

    [JsonPropertyName("favourite_count")] public int? FavouriteCount { get; set; }

    [JsonPropertyName("hype")] public Hype? Hype { get; set; }

    [JsonPropertyName("id")] [NotNull] public int? Id { get; set; }

    [JsonPropertyName("nsfw")] public bool? Nsfw { get; set; }

    [JsonPropertyName("offset")] public int? Offset { get; set; }

    [JsonPropertyName("play_count")] public int? PlayCount { get; set; }

    [JsonPropertyName("preview_url")] public string? PreviewUrl { get; set; }

    [JsonPropertyName("source")] public string? Source { get; set; }

    [JsonPropertyName("spotlight")] public bool? Spotlight { get; set; }

    [JsonPropertyName("status")] public string? Status { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("title_unicode")] public string? TitleUnicode { get; set; }

    [JsonPropertyName("track_id")] public int? TrackId { get; set; }

    [JsonPropertyName("user_id")] public int? UserId { get; set; }

    [JsonPropertyName("video")] public bool? Video { get; set; }

    [JsonPropertyName("nominations_summary")]
    public NominationsSummary? NominationsSummary { get; set; }

    [JsonPropertyName("rating")] public float? Rating { get; set; }

    [JsonPropertyName("availability")] public Availability? Availability { get; set; }

    [JsonPropertyName("beatmaps")] public List<Beatmap>? Beatmaps { get; set; }

    [JsonPropertyName("converts")] public List<Beatmap>? Converts { get; set; }

    [JsonPropertyName("current_nominations")]
    public List<object>? CurrentNominations { get; set; }

    [JsonPropertyName("description")] public Description? Description { get; set; }

    [JsonPropertyName("genre")] public Genre? Genre { get; set; }

    [JsonPropertyName("language")] public Language? Language { get; set; }

    [JsonPropertyName("pack_tags")] public List<string>? PackTags { get; set; }

    [JsonPropertyName("ratings")] public List<int>? Ratings { get; set; }

    [JsonPropertyName("recent_favourites")]
    public List<User>? RecentFavourites { get; set; }

    [JsonPropertyName("related_users")] public List<User>? RelatedUsers { get; set; }

    [JsonPropertyName("related_tags")] public List<object>? RelatedTags { get; set; }

    [JsonPropertyName("user")] public User? User { get; set; }
}