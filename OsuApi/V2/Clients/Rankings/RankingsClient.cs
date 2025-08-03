using OsuApi.V2.Clients.Rankings.HttpIO;
using OsuApi.V2.Extensions;
using OsuApi.V2.Extensions.Types;
using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Rankings;

public sealed class RankingsClient : Client
{
    public RankingsClient(Api api) : base(api)
    {
    }

    /// <summary>
    ///     Gets the current ranking for the specified type and game mode.
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="rankingType"></param>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Models.Rankings?> GetRanking(string mode, string rankingType,
        GetRankingQueryParameters parameters, CancellationToken? cancellationToken = null)
    {
        ApiUtility.ThrowIfParameterValueIsNotOfType(mode, typeof(Ruleset));

        var response = await Api.MakeRequestAsync<Models.Rankings>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/rankings/{mode}/{rankingType}",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );

        return response;
    }
}