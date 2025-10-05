using Microsoft.Extensions.Logging;
using OsuApi.V2;
using OsuApi.V2.Extensions.Types;

namespace OsuApi;

/// <summary>
///     A base class for osu!api
/// </summary>
public abstract class Api : IRequestMaker, IDisposable
{
    /// <summary>
    ///     An http client for an api communication
    /// </summary>
    protected abstract HttpClient? HttpClient { get; set; }

    /// <summary>
    ///     A logger used in api classes to log various information
    /// </summary>
    internal abstract ILogger Logger { get; set; }

    /// <summary>
    ///     Support for a disposable pattern
    /// </summary>
    public abstract void Dispose();

    /// <summary>
    ///     Base method for any api requests
    /// </summary>
    /// <param name="url">Request url</param>
    /// <param name="httpMethod">Request http method</param>
    /// <param name="queryParameters">Query parameters in url</param>
    /// <param name="content">http request content</param>
    /// <param name="updateTokenIfNeeded">Set to true, if the token should be renewed upon expiration </param>
    /// <param name="setAuthorizationHeader">Set to true, if the authorization header in http request should be set</param>
    /// <param name="cancellationToken">Cancellation token to stop the execution of this method</param>
    /// <typeparam name="T">Response type</typeparam>
    /// <returns>Response</returns>
    public abstract Task<T?> MakeRequestAsync<T>(
        string url,
        HttpMethod httpMethod,
        QueryParameters? queryParameters = null,
        HttpContent? content = null,
        bool updateTokenIfNeeded = true,
        bool setAuthorizationHeader = true,
        CancellationToken? cancellationToken = null) where T : class;

    /// <summary>
    ///     A method to initialize an api
    /// </summary>
    /// <returns>
    ///     <see cref="Task" />
    /// </returns>
    protected abstract Task Initialize();

    /// <summary>
    ///     Get base api endpoint
    /// </summary>
    /// <param name="apiVersion">Api version (V1/V2)</param>
    /// <returns>Base url as string</returns>
    /// <exception cref="NotImplementedException">Throws if any other api version than v1/v2 was provided</exception>
    protected static string GetBaseUrl(ApiVersion apiVersion)
    {
        return apiVersion switch
        {
            ApiVersion.ApiV1 => "https://osu.ppy.sh/api/v1",
            ApiVersion.ApiV2 => "https://osu.ppy.sh/api/v2",
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    ///     Current api version
    /// </summary>
    /// <returns>Api version</returns>
    public abstract ApiVersion CurrentApiVersion();
}