using OsuApi.Core.V2.Beatmaps;
using OsuApi.Core.V2.Beatmapsets;
using OsuApi.Core.V2.Extensions;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using OsuApi.Core.V2.Scores;
using OsuApi.Core.V2.Users;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace OsuApi.Core.V2
{
    public class ApiV2 : Api
    {
        public readonly static string ApiMainFunctionsBaseAddress = Api.GetBaseUrl(ApiVersion.ApiV2);
        public readonly ApiConfiguration ApiConfiguration;
        public override ApiVersion CurrentApiVersion => ApiVersion.ApiV2;

        public ScoresClient Scores { get; init; }
        public UsersClient Users { get; init; }
        public BeatmapsClient Beatmaps { get; init; }
        public BeatmapsetsClient Beatmapsets { get; init; }

        protected override HttpClient? HttpClient { get; set; }
        protected GrantAccess? GrantAccess { get; set; }
        protected CancellationToken CancellationToken { get; set; }
        protected override bool IsInitialized { get; set; }

        private CancellationTokenSource? _cancellationTokenSource;
        private ApiResponseVersion _apiResponseVersion = ApiResponseVersion.V20240529;

        public void SetApiResponseVersion(ApiResponseVersion apiResponseVersion)
        {
            if (apiResponseVersion != ApiResponseVersion.V20240529) throw new Exception("Not supported");

            _apiResponseVersion = apiResponseVersion;
        }

        public ApiV2(int client_id, string client_secret, HttpClient? httpClient = null, CancellationToken? cancellationToken = null)
        {
            _cancellationTokenSource = cancellationToken is null ? new CancellationTokenSource() : null;
            HttpClient = httpClient ?? new HttpClient();
            CancellationToken = cancellationToken ?? _cancellationTokenSource!.Token;

            ApiConfiguration = new ApiConfiguration(client_id, client_secret);
            SetDefaultRequestHeaders();
            Initialize().Wait();

            Scores = new ScoresClient(this);
            Users = new UsersClient(this);
            Beatmaps = new BeatmapsClient(this);
            Beatmapsets = new BeatmapsetsClient(this);
        }

        protected override async Task Initialize()
        {
            if (HttpClient == null) throw new Exception();

            GrantAccess = new GrantAccess(ApiConfiguration, this);
            await GrantAccess.ClientCredentialGrant();

            IsInitialized = true;
        }

        private void SetDefaultRequestHeaders()
        {
            if (HttpClient == null) throw new Exception();

            HttpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            HttpClient.DefaultRequestHeaders.Add("x-api-version", $"{(int)_apiResponseVersion}");
        }

        /// <summary>
        /// Makes an HTTP request with given QueryParameters
        /// </summary>
        /// <typeparam name="T">Response type to be decoded from json</typeparam>
        /// <param name="url">Url for current http request</param>
        /// <param name="httpMethod">HTTP Method to use.</param>
        /// <param name="queryParameters">Query parameter to pass into url. Can be null, if none query parameters specified</param>
        /// <param name="content">Body content of the request</param>
        /// <param name="updateTokenIfNeeded">Should the token be updated before the request if it's outdated</param>
        /// <param name="setAuthorizationHeader">Should the auth header be set</param>
        /// <returns>A response of the type T</returns>
        public override async Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true) where T : class
        {
            if (GrantAccess == null) throw new Exception();
            if (HttpClient == null) throw new Exception();

            if (updateTokenIfNeeded) await GrantAccess.UpdateTokenIfNeeded();

            using var httpRequest = new HttpRequestMessage(httpMethod, url);
            httpRequest.Content = content;
            if (setAuthorizationHeader) httpRequest.SetAuthorizationHeader($"{GrantAccess.GetTokenType()} {GrantAccess.GetAccessToken()}");
            if (queryParameters != null) httpRequest.SetQueryParameters(queryParameters.QueryProperties, queryParameters.ParametersClassInstance);

            var httpResponse = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);
            if (!httpResponse.IsSuccessStatusCode) return null;

#if DEBUG
            Console.WriteLine("\n\n\n\n" + await httpResponse.Content.ReadAsStringAsync());
#endif

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
