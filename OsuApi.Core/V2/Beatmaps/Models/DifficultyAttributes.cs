using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models
{
    public record DifficultyAttributes
    {
        [JsonPropertyName("max_combo")]
        public int? MaxCombo { get; set; }

        [JsonPropertyName("star_rating")]
        public float? StarRating { get; set; }
    }
}