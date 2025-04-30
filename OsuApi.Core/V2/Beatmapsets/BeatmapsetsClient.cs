using OsuApi.Core.V2.Beatmaps.Models.HttpIO;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmapsets
{
    public class BeatmapsetsClient : Client
    {
        public BeatmapsetsClient(Api api) : base(api) { }

        public async Task<BeatmapsetExtended> GetBeatmapset(int beatmapset)
        {
            var response = await Api.MakeRequestAsync<BeatmapsetExtended>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmapsets/{beatmapset}",
                HttpMethod.Get,
                null
            );
            if (response == default) throw new Exception();

            return response;
        }
    }
}
