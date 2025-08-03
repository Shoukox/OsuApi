using OsuApi.V2.Extensions.Types;

namespace OsuApi.V2;

internal interface IRequestMaker
{
    public Task<T?> MakeRequestAsync<T>(
        string url,
        HttpMethod httpMethod,
        QueryParameters? queryParameters = null,
        HttpContent? content = null,
        bool updateTokenIfNeeded = true,
        bool setAuthorizationHeader = true,
        CancellationToken? cancellationToken = null) where T : class;
}