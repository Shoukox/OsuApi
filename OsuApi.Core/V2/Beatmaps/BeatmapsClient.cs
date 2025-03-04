using OsuApi.Core.V2.Beatmaps.Models;
using OsuApi.Core.V2.Beatmaps.Models.HttpIO;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores.Models;
using OsuApi.Core.V2.Scores.Models.HttpIO;
using OsuApi.Core.V2.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Beatmaps
{
    public sealed class BeatmapsClient : Client
    {
        public BeatmapsClient(Api api) : base(api) { }

        public async Task<LookupBeatmapResponse> LookupBeatmap(LookupBeatmapQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<BeatmapExtended>(
                url: ApiV2.ApiMainFunctionsBaseAddress + "/beatmaps/lookup",
                HttpMethod.Get,
                new QueryParameters(typeof(LookupBeatmapQueryParameters).GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new LookupBeatmapResponse { BeatmapExtended = response };
        }

        public async Task<GetUserBeatmapScoreResponse> GetUserBeatmapScore(long beatmap, long user, GetUserBeatmapScoreQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<BeatmapUserScore>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/scores/users/{user}",
                HttpMethod.Get,
                new QueryParameters(typeof(GetUserBeatmapScoreQueryParameters).GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserBeatmapScoreResponse { BeatmapUserScore = response };
        }

        public async Task<GetUserBeatmapScoresResponse> GetUserBeatmapScores(long beatmap, long user, GetUserBeatmapScoresQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<GetUserBeatmapScoresResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/scores/users/{user}/all",
                HttpMethod.Get,
                new QueryParameters(typeof(GetUserBeatmapScoresQueryParameters).GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return response;
        }

        /// <summary>
        /// (Only osu! std) Returns difficulty attributes of beatmap with specific mode and mods combination.
        /// </summary>
        /// <param name="beatmap">Beatmap id.</param>
        /// <param name="parameters">Body Parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetBeatmapAttributesResponse> GetBeatmapAttributes(long beatmap, GetBeatmapAttributesRequest parameters)
        {
            var response = await Api.MakeRequestAsync<GetBeatmapAttributesResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/attributes",
                HttpMethod.Post,
                content: JsonContent.Create(parameters)
            );
            if (response == default) throw new Exception();

            return response;
        }
    }
}
