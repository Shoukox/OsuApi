using OsuApi.Core.V2.Clients.Beatmaps.HttpIO;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.Models;
using OsuApi.Core.V2.Users.Models;
using System.Net.Http.Json;

namespace OsuApi.Core.V2.Clients.Beatmaps
{
    public sealed class BeatmapsClient : Client
    {
        public BeatmapsClient(Api api) : base(api) { }

        public async Task<LookupBeatmapResponse> LookupBeatmap(LookupBeatmapQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<BeatmapExtended>(
                url: ApiV2.ApiMainFunctionsBaseAddress + "/beatmaps/lookup",
                HttpMethod.Get,
                new QueryParameters(typeof(LookupBeatmapQueryParameters).GetProperties(), parameters),
                cancellationToken: cancellationToken
            );
            if (response == default) throw new Exception();

            return new LookupBeatmapResponse { BeatmapExtended = response };
        }

        public async Task<GetUserBeatmapScoreResponse?> GetUserBeatmapScore(long beatmap, long user, GetUserBeatmapScoreQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<BeatmapUserScore>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/scores/users/{user}",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return new GetUserBeatmapScoreResponse { BeatmapUserScore = response };
        }

        public async Task<GetUserBeatmapScoresResponse?> GetUserBeatmapScores(long beatmap, long user, GetUserBeatmapScoresQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<GetUserBeatmapScoresResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/scores/users/{user}/all",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );

            return response;
        }

        public async Task<GetBeatmapScoresResponse?> GetBeatmapScores(long beatmap, GetBeatmapScoresQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<BeatmapScores>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/scores",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return new GetBeatmapScoresResponse { BeatmapScores = response };
        }

        public async Task<GetBeatmapScoresResponse?> GetBeatmapScoresNonLegacy(long beatmap, GetBeatmapScoresQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<BeatmapScores>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/solo-scores",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return new GetBeatmapScoresResponse { BeatmapScores = response };
        }

        public async Task<GetBeatmapResponse?> GetBeatmap(long beatmap, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<BeatmapExtended>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}",
                HttpMethod.Get,
                null,
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return new GetBeatmapResponse { BeatmapExtended = response };
        }

        public async Task<GetBeatmapsResponse?> GetBeatmaps(long beatmap, GetBeatmapsQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<GetBeatmapsResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return response;
        }

        /// <summary>
        /// (Only osu! std) Returns difficulty attributes of beatmap with specific mode and mods combination.
        /// </summary>
        /// <param name="beatmap">Beatmap id.</param>
        /// <param name="parameters">Body Parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetBeatmapAttributesResponse?> GetBeatmapAttributes(long beatmap, GetBeatmapAttributesRequest parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<GetBeatmapAttributesResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + $"/beatmaps/{beatmap}/attributes",
                HttpMethod.Post,
                content: JsonContent.Create(parameters),
                cancellationToken: cancellationToken
            );
            if (response is null) return null;

            return response;
        }
    }
}
