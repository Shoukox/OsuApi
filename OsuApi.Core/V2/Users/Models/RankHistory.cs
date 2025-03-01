﻿using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record RankHistory
    {
        /// <summary>
        /// See <see cref="Scores.Models.Ruleset"/>
        /// </summary>
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [JsonPropertyName("data")]
        public int[]? Data { get; set; }
    }
}
