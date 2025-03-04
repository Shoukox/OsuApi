using OsuApi.Core.V2.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public class GetBeatmapAttributesResponse
    {
        [JsonPropertyName("attributes")]
        public OsuDifficultyAttributes? DifficultyAttributes { get; set; }
    }
}
