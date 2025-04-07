using OsuApi.Core.V2.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record GetBeatmapsQueryParameters
    {
        [QueryParameter("ids[]")]
        public int[]? BeatmapIds { get; set; }
    }
}
