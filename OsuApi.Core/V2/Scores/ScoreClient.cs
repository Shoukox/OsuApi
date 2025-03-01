using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores.Models.HttpIO;

namespace OsuApi.Core.V2.Scores
{
    public class ScoreClient : Client
    {
        public ScoreClient(HttpClient httpClient, GrantAccess grantAccess) : base(httpClient, grantAccess) { }

        public async Task<ScoresResponse> GetScores(ScoresQueryParameters parameters)
        {
            if (HttpClient == null) throw new Exception();

            var response = await MakeRequestAsync<ScoresResponse>(
                url: ApiV2.ApiMainFunctionsBaseAddress + "/scores",
                new QueryParameters(typeof(ScoresQueryParameters).GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return response;
        }
    }
}
