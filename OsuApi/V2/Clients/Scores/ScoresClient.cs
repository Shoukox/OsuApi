using OsuApi.V2.Clients.Scores.HttpIO;
using OsuApi.V2.Extensions.Types;
using OsuApi.V2.Models;

namespace OsuApi.V2.Clients.Scores;

public sealed class ScoresClient : Client
{
    public ScoresClient(Api api) : base(api)
    {
    }

    public async Task<ScoresResponse?> GetScores(ScoresQueryParameters parameters,
        CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<ScoresResponse>(
            ApiV2.ApiMainFunctionsBaseAddress + "/scores",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );

        return response;
    }

    public async Task<Score?> GetScore(long scoreId, CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<Score>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/scores/{scoreId}",
            HttpMethod.Get,
            null,
            cancellationToken: cancellationToken
        );

        return response;
    }

    public async Task<Stream> DownloadScoreReplay(long scoreId, CancellationToken? cancellationToken = null)
    {
        var apiV2 = Api as ApiV2;
        var response = await apiV2.MakeRequestAsync(
            url: ApiV2.ApiMainFunctionsBaseAddress + $"/scores/{scoreId}/download",
            HttpMethod.Get,
            null,
            cancellationToken: cancellationToken
        );

        return response;
    }
}
