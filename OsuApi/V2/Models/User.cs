using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record User
    {
        /// <summary>
        /// Url of user's avatar
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }

        /// <summary>
        /// Two-letter code representing user's country
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Identifier of the default Group the user belongs to.
        /// </summary>
        [JsonPropertyName("default_group")]
        public string? DefaultGroup { get; set; }

        /// <summary>
        /// Unique identifier for user. Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public long? Id { get; set; }

        /// <summary>
        /// Has this account been active in the last x months?
        /// </summary>
        [JsonPropertyName("is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Is this a bot account?
        /// </summary>
        [JsonPropertyName("is_bot")]
        public bool? IsBot { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Is the user currently online? (either on lazer or the new website)
        /// </summary>
        [JsonPropertyName("is_online")]
        public bool? IsOnline { get; set; }

        /// <summary>
        /// Does this user have supporter?
        /// </summary>
        [JsonPropertyName("is_supporter")]
        public bool? IsSupporter { get; set; }

        /// <summary>
        /// Last access time. null if the user hides online presence
        /// </summary>
        [JsonPropertyName("last_visit")]
        public DateTime? LastVisit { get; set; }

        /// <summary>
        /// Whether or not the user allows PM from other than friends
        /// </summary>
        [JsonPropertyName("pm_friends_only")]
        public bool? PmFriendsOnly { get; set; }

        /// <summary>
        /// Colour of username/profile highlight, hex code (e.g.
        /// </summary>
        [JsonPropertyName("profile_colour")]
        public string? ProfileColour { get; set; }

        /// <summary>
        /// User's display name
        /// </summary>
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("account_history")]
        public UserAccountHistory[]? AccountHistory { get; set; }

        /// <summary>
        /// Deprecated, use <see cref="ActiveTournamentBanners">ActiveTournamentBanners</see> instead.
        /// </summary>
        [JsonPropertyName("active_tournament_banner")]
        public UserProfileBanner? ActiveTournamentBanner { get; set; }

        [JsonPropertyName("active_tournament_banners")]
        public UserProfileBanner[]? ActiveTournamentBanners { get; set; }

        [JsonPropertyName("badges")]
        public UserBadge[]? Badges { get; set; }

        [JsonPropertyName("beatmap_playcounts_count")]
        public int? BeatmapPlaycountsCount { get; set; }

        [JsonPropertyName("blocks")]
        public object? Blocks { get; set; } // idk what is it

        [JsonPropertyName("country")]
        public Country? Country { get; set; }

        [JsonPropertyName("cover")]
        public Cover? Cover { get; set; }

        [JsonPropertyName("favourite_beatmapset_count")]
        public int? FavouriteBeatmapsetCount { get; set; }

        [JsonPropertyName("follow_user_mapping")]
        public int[]? FollowUserMapping { get; set; }

        [JsonPropertyName("follower_count")]
        public int? FollowerCount { get; set; }

        [JsonPropertyName("friends")]
        public object? Friends { get; set; } // idk

        [JsonPropertyName("graveyard_beatmapset_count")]
        public int? GraveyardBeatmapsetCount { get; set; }

        [JsonPropertyName("groups")]
        public UserGroup[]? Groups { get; set; }

        [JsonPropertyName("guest_beatmapset_count")]
        public int? GuestBeatmapsetCount { get; set; }

        [JsonPropertyName("is_restricted")]
        public bool? IsRestricted { get; set; }

        [JsonPropertyName("kudosu")]
        public Kudosu? Kudosu { get; set; }

        [JsonPropertyName("loved_beatmapset_count")]
        public int? LovedBeatmapsetCount { get; set; }

        [JsonPropertyName("mapping_follower_count")]
        public int? MappingFollowerCount { get; set; }

        [JsonPropertyName("monthly_playcounts")]
        public UserMonthlyPlaycount[]? MonthlyPlaycounts { get; set; }

        [JsonPropertyName("page")]
        public Page? Page { get; set; }

        [JsonPropertyName("pending_beatmapset_count")]
        public int? PendingBeatmapsetCount { get; set; }

        [JsonPropertyName("previous_usernames")]
        public string[]? PreviousUsernames { get; set; }

        [JsonPropertyName("rank_highest")]
        public UserRankHighest? RankHighest { get; set; }

        [JsonPropertyName("rank_history")]
        public RankHistory? RankHistory { get; set; }

        [JsonPropertyName("ranked_beatmapset_count")]
        public int? RankedBeatmapsetCount { get; set; }

        [JsonPropertyName("replays_watched_counts")]
        public ReplaysWatchedCount[]? ReplaysWatchedCounts { get; set; }

        [JsonPropertyName("scores_best_count")]
        public int? ScoresBestCount { get; set; }

        [JsonPropertyName("scores_first_count")]
        public int? ScoresFirstCount { get; set; }

        [JsonPropertyName("scores_recent_count")]
        public int? ScoresRecentCount { get; set; }

        [JsonPropertyName("session_verified")]
        public bool? SessionVerified { get; set; }

        [JsonPropertyName("statistics")]
        public UserStatistics? Statistics { get; set; }

        [JsonPropertyName("statistics_rulesets")]
        public UserStatisticsRulesets? StatisticsRulesets { get; set; }

        [JsonPropertyName("support_level")]
        public int? SupportLevel { get; set; }

        [JsonPropertyName("unread_pm_count")]
        public object? UnreadPmCount { get; set; }

        [JsonPropertyName("user_achievements")]
        public UserAchievement[]? UserAchievements { get; set; }

        [JsonPropertyName("user_preferences")]
        public object? UserPreferences { get; set; }

        [JsonPropertyName("team")]
        public Team? Team { get; set; }
    }
}
