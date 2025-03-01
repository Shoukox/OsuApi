﻿using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Scores.Models
{
    class MaximumStatistics
    {
        [JsonPropertyName("great")]
        public int? Great { get; set; }

        [JsonPropertyName("legacy_combo_increase")]
        public int? LegacyComboIncrease { get; set; }
    }
}
