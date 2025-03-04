using OsuApi.Core.V2.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models
{
    public record BeatmapUserScore
    {
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        [JsonPropertyName("score")]
        public Score? Score { get; set; }
    }
}
