using OsuApi.Core.V2.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public class GetUserBeatmapScoreQueryParameters
    {
        [QueryParameter("legacy_only")]
        public string? LegacyOnly { get; set; }

        /// <summary>
        /// See <see cref="Scores.Models.Ruleset"/>
        /// </summary>
        [QueryParameter("mode")]
        public string? Mode { get; set; }

        [QueryParameter("mods")]
        public string? Mods { get; set; }
    }
}
