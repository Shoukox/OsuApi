using OsuApi.Core.V2.Extensions;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using System.Net.Http.Json;

namespace OsuApi.Core.V2
{
    public abstract class Client
    {
        public GrantAccess GrantAccess;
        public HttpClient HttpClient;

        public Client(HttpClient httpClient, GrantAccess grantAccess)
        {
            GrantAccess = grantAccess;
            HttpClient = httpClient;
        }

        /// <summary>
        /// Makes an GET HTTP request with given QueryParameters
        /// </summary>
        /// <typeparam name="T">Response type to be decoded from json</typeparam>
        /// <param name="url">Url for current http request</param>
        /// <param name="queryParameters">Query parameter to pass into url. Can be null, if none query parameters specified</param>
        /// <returns>A response of the type T</returns>
        public async Task<T?> MakeRequestAsync<T>(string url, QueryParameters? queryParameters = null)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            httpRequest.SetAuthorizationHeader($"{GrantAccess.GetTokenType()} {GrantAccess.GetAccessToken()}");

            if (queryParameters != null) httpRequest.SetQueryParameters(queryParameters.QueryProperties, queryParameters.ParametersClassInstance);

            var httpResponse = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);
            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<T>();
        }
    }
}
