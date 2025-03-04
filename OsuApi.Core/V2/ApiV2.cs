using OsuApi.Core.V2.Beatmaps;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.Extensions;
using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores;
using OsuApi.Core.V2.Users;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;

namespace OsuApi.Core.V2
{
    public class ApiV2 : Api
    {
        public const string ApiGrantAccessBaseAddress = "https://osu.ppy.sh/oauth/token";
        public readonly static string ApiMainFunctionsBaseAddress = Api.GetBaseUrl(ApiVersion.ApiV2);

        public ScoresClient Scores { get; init; }
        public UsersClient Users { get; init; }
        public BeatmapsClient Beatmaps { get; init; }

        protected override HttpClient? HttpClient { get; set; }
        protected GrantAccess? GrantAccess { get; set; }
        protected CancellationTokenSource Cts;
        private int _client_id;
        private string _client_secret;
        private ApiResponseVersion _apiResponseVersion = ApiResponseVersion.V20240529;

        public void SetApiResponseVersion(ApiResponseVersion apiResponseVersion)
        {
            if (apiResponseVersion != ApiResponseVersion.V20240529) throw new Exception("Not supported");

            _apiResponseVersion = apiResponseVersion;
        }

        public ApiV2(int client_id, string client_secret)
        {
            HttpClient = new HttpClient();
            Cts = new CancellationTokenSource();
            _client_id = client_id;
            _client_secret = client_secret;

            SetDefaultRequestHeaders();
            Initialize().Wait(); // grantAccess is not null

            Scores = new ScoresClient(this);
            Users = new UsersClient(this);
            Beatmaps = new BeatmapsClient(this);
        }

        protected override async Task Initialize()
        {
            if (HttpClient == null) throw new Exception();

            GrantAccess = new GrantAccess(_client_id, _client_secret, this);
            await GrantAccess.GetClientCredentialGrant();
        }

        private void SetDefaultRequestHeaders()
        {
            if (HttpClient == null) throw new Exception();

            HttpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            HttpClient.DefaultRequestHeaders.Add("x-api-version", $"{(int)_apiResponseVersion}");
        }

        /// <summary>
        /// Makes an GET HTTP request with given QueryParameters
        /// </summary>
        /// <typeparam name="T">Response type to be decoded from json</typeparam>
        /// <param name="url">Url for current http request</param>
        /// <param name="queryParameters">Query parameter to pass into url. Can be null, if none query parameters specified</param>
        /// <returns>A response of the type T</returns>
        public override async Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true) where T : class
        {
            if (GrantAccess == null) throw new Exception();
            if (HttpClient == null) throw new Exception();

            if (updateTokenIfNeeded) await GrantAccess.UpdateTokenIfNeeded();

            using var httpRequest = new HttpRequestMessage(httpMethod, url);
            if (setAuthorizationHeader) httpRequest.SetAuthorizationHeader($"{GrantAccess.GetTokenType()} {GrantAccess.GetAccessToken()}");
            httpRequest.Content = content;

            if (queryParameters != null) httpRequest.SetQueryParameters(queryParameters.QueryProperties, queryParameters.ParametersClassInstance);

            var httpResponse = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

            var a = await httpResponse.Content.ReadAsStringAsync();

            httpResponse.EnsureSuccessStatusCode();

            //Console.WriteLine(await httpResponse.Content.ReadAsStringAsync());

            return await httpResponse.Content.ReadFromJsonAsync<T>();
        }

        #region Dispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (HttpClient != null) HttpClient.Dispose();
                    if (GrantAccess != null) GrantAccess.Dispose();
                }

                disposedValue = true;
            }
        }

        public override void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
