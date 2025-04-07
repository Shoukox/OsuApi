using OsuApi.Core.V2.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record GetBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
