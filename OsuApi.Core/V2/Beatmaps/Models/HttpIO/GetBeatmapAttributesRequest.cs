using OsuApi.Core.V2.Extensions.Attributes;
using OsuApi.Core.V2.Scores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public class GetBeatmapAttributesRequest
    {
        /// <summary>
        /// See <see cref="Ruleset"/>
        /// </summary>
        [QueryParameter("ruleset")]
        public string? Ruleset { get; set; }

        /// <summary>
        /// The same as <see cref="Ruleset"/> but in integer form.
        /// </summary>
        [QueryParameter("ruleset_id")]
        public string? RulesetId { get; set; }
        
        [QueryParameter("mods")]
        public Mod[]? Mods { get; set; }
    }
}
