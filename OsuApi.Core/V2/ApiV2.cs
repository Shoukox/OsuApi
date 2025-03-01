using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores;
using OsuApi.Core.V2.Users;
using System.Net.Http.Headers;

namespace OsuApi.Core.V2
{
    public class ApiV2 : Api
    {
        public const string ApiGrantAccessBaseAddress = "https://osu.ppy.sh/oauth/token";
        public const string ApiMainFunctionsBaseAddress = ApiBaseUrl.V2;

        protected override HttpClient? HttpClient { get; set; }
        protected GrantAccess? GrantAccess { get; set; }

        protected CancellationTokenSource Cts;

        public ScoreClient Score { get; init; }
        public UsersClient Users { get; init; }

        private bool _startWorker = false;
        private int _client_id;
        private string _client_secret;

        public ApiV2(int client_id, string client_secret, bool startWorker = true)
        {
            HttpClient = new HttpClient();
            Cts = new CancellationTokenSource();
            _startWorker = startWorker;
            _client_id = client_id;
            _client_secret = client_secret;

            SetDefaultRequestHeaders();
            GrantAccessFunction(); // grantAccess is not null

            Score = new ScoreClient(HttpClient, GrantAccess!);
            Users = new UsersClient(HttpClient, GrantAccess!);
        }

        protected override void GrantAccessFunction()
        {
            if (HttpClient == null) throw new Exception();

            GrantAccess = GrantAccess.Initialize(_client_id, _client_secret, HttpClient);
            GrantAccess.GetClientCredentialGrant().Wait();

            if (_startWorker)
            {
                // Update access grant in another async method
                Task.Factory.StartNew((o) => GrantAccess.StartWorker(Cts.Token), TaskCreationOptions.LongRunning);
            }
        }

        private void SetDefaultRequestHeaders()
        {
            if (HttpClient == null) throw new Exception();

            HttpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
        }

        public override void Dispose()
        {
            //todo
            //GC.SuppressFinalize()
        }
    }
}
