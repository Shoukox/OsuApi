using Microsoft.Extensions.Logging;
using OsuApi.V2;
using OsuApi.V2.Extensions.Types;

namespace OsuApi;

public abstract class Api : IRequestMaker, IDisposable
{
    protected abstract HttpClient? HttpClient { get; set; }

    public abstract ILogger Logger { get; set; }
    public abstract void Dispose();

    public abstract Task<T?> MakeRequestAsync<T>(
        string url,
        HttpMethod httpMethod,
        QueryParameters? queryParameters = null,
        HttpContent? content = null,
        bool updateTokenIfNeeded = true,
        bool setAuthorizationHeader = true,
        CancellationToken? cancellationToken = null) where T : class;

    protected abstract Task Initialize();

    protected static string GetBaseUrl(ApiVersion apiVersion)
    {
        return apiVersion switch
        {
            ApiVersion.ApiV1 => "https://osu.ppy.sh/api/v1",
            ApiVersion.ApiV2 => "https://osu.ppy.sh/api/v2",
            _ => throw new NotImplementedException()
        };
    }

    public abstract ApiVersion CurrentApiVersion();
}