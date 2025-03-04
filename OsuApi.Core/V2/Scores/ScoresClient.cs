using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores.Models.HttpIO;

namespace OsuApi.Core.V2.Scores
{
    public sealed class ScoresClient : Client
    {
        public ScoresClient(Api api) : base(api) { }

        public async Task<ScoresResponse> GetScores(ScoresQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<ScoresResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + "/scores",
                HttpMethod.Get,
                new QueryParameters(typeof(ScoresQueryParameters).GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return response;
        }
    }
}
