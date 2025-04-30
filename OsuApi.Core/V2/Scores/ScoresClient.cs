using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.Scores.Models.HttpIO;

namespace OsuApi.Core.V2.Scores
{
    public sealed class ScoresClient : Client
    {
        public ScoresClient(Api api) : base(api) { }

        public async Task<ScoresResponse?> GetScores(ScoresQueryParameters parameters, CancellationToken? cancellationToken = null)
        {
            var response = await Api.MakeRequestAsync<ScoresResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + "/scores",
                HttpMethod.Get,
                new QueryParameters(parameters.GetType().GetProperties(), parameters),
                cancellationToken: cancellationToken
            );

            return response;
        }
    }
}
