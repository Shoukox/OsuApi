using System.Text.Json.Serialization;
using OsuApi.V2.Extensions.Converters;

namespace OsuApi.V2.Users.Models;

public record BeatmapsetExtended : Beatmapset
{
    [JsonPropertyName("availability.download_disabled")]
    public bool? AvailabilityDownloadDisabled { get; set; }

    [JsonPropertyName("availability.more_information")]
    public string? AvailabilityMoreInformation { get; set; }

    [JsonPropertyName("bpm")] public float? Bpm { get; set; }

    [JsonPropertyName("can_be_hyped")] public bool? CanBeHyped { get; set; }

    [JsonPropertyName("deleted_at")]
    [JsonConverter(typeof(TimestampJsonConverter))]
    public Timestamp? DeletedAt { get; set; }

    [JsonPropertyName("discussion_enabled")]
    public bool? DiscussionEnabled { get; set; }

    [JsonPropertyName("discussion_locked")]
    public bool? DiscussionLocked { get; set; }

    [JsonPropertyName("is_scoreable")] public bool? IsScoreable { get; set; }

    [JsonPropertyName("last_updated")]
    [JsonConverter(typeof(TimestampJsonConverter))]
    public Timestamp? LastUpdated { get; set; }

    [JsonPropertyName("legacy_thread_url")]
    public string? LegacyThreadUrl { get; set; }

    [JsonPropertyName("nominations_summary.current")]
    public int? NominationsSummaryCurrent { get; set; }

    [JsonPropertyName("nominations_summary.required")]
    public int? NominationsSummaryRequired { get; set; }

    [JsonPropertyName("ranked")] public RankStatus? Ranked { get; set; }

    [JsonPropertyName("ranked_date")]
    [JsonConverter(typeof(TimestampJsonConverter))]
    public Timestamp? RankedDate { get; set; }

    [JsonPropertyName("storyboard")] public bool? Storyboard { get; set; }

    [JsonPropertyName("submitted_date")]
    [JsonConverter(typeof(TimestampJsonConverter))]
    public Timestamp? SubmittedDate { get; set; }

    [JsonPropertyName("tags")] public string? Tags { get; set; }

    [JsonPropertyName("has_favourited")] public bool? HasFavourited { get; set; }
}