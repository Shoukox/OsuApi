﻿using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public record LookupBeatmapResponse
    {
        public BeatmapExtended? BeatmapExtended { get; set; }
    }
}
