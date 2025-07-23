using OsuApi.V2.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using OsuApi.V2.Clients.Beatmaps;
using OsuApi.V2.Clients.Beatmapsets;
using OsuApi.V2.Clients.Rankings;
using OsuApi.V2.Clients.Scores;
using OsuApi.V2.Clients.Users;
using OsuApi.V2.Extensions.Types;
using OsuApi.V2.Utilities.GrantAccessUtility;

namespace OsuApi.V2
{
    public class ApiV2 : Api
    {
        public readonly static string ApiMainFunctionsBaseAddress = Api.GetBaseUrl(ApiVersion.ApiV2);
        public readonly ApiConfiguration ApiConfiguration;
        public override ApiVersion CurrentApiVersion() => ApiVersion.ApiV2;

        public ScoresClient Scores { get; init; }
        public UsersClient Users { get; init; }
        public BeatmapsClient Beatmaps { get; init; }
        public BeatmapsetsClient Beatmapsets { get; init; }
        public RankingsClient Rankings { get; init; }

        protected override HttpClient? HttpClient { get; set; }
        protected GrantAccess? GrantAccess { get; set; }

        public bool IsInitialized { get; set; }

        private ApiResponseVersion _apiResponseVersion = ApiResponseVersion.V20240529;

        public void SetApiResponseVersion(ApiResponseVersion apiResponseVersion)
        {
            if (apiResponseVersion != ApiResponseVersion.V20240529) throw new Exception("Not supported");

            _apiResponseVersion = apiResponseVersion;
        }

        public ApiV2(int client_id, string client_secret, HttpClient? httpClient = null)
        {
            HttpClient = httpClient ?? new HttpClient();

            ApiConfiguration = new ApiConfiguration(client_id, client_secret);
            SetDefaultRequestHeaders();
            Initialize().Wait();

            Scores = new ScoresClient(this);
            Users = new UsersClient(this);
            Beatmaps = new BeatmapsClient(this);
            Beatmapsets = new BeatmapsetsClient(this);
            Rankings = new RankingsClient(this);
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
        public override async Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true, CancellationToken? cancellationToken = null) where T : class
        {
            cancellationToken ??= CancellationToken.None;

            if (GrantAccess == null) throw new Exception();
            if (HttpClient == null) throw new Exception();

            if (updateTokenIfNeeded) await GrantAccess.UpdateTokenIfNeeded();
            cancellationToken?.ThrowIfCancellationRequested();

            using var httpRequest = new HttpRequestMessage(httpMethod, url);
            httpRequest.Content = content;
            if (setAuthorizationHeader) httpRequest.SetAuthorizationHeader($"{GrantAccess.GetTokenType()} {GrantAccess.GetAccessToken()}");
            if (queryParameters != null) httpRequest.SetQueryParameters(queryParameters.QueryProperties, queryParameters.ParametersClassInstance);
            cancellationToken?.ThrowIfCancellationRequested();

            var httpResponse = await HttpClient.SendAsync(httpRequest, cancellationToken!.Value).ConfigureAwait(false);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Request failed with status code {(int)httpResponse.StatusCode} ({httpResponse.StatusCode}).");
            }

#if DEBUG
            Console.WriteLine("\n\n\n\n" + await httpResponse.Content.ReadAsStringAsync(cancellationToken!.Value));
#endif

            return await httpResponse.Content.ReadFromJsonAsync<T>(cancellationToken!.Value);
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
