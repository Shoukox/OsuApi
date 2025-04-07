using OsuApi.Core.V2.Extensions.Types;

namespace OsuApi.Core.V2
{
    interface IRequestMaker
    {
        public Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true) where T : class;
    }
}
