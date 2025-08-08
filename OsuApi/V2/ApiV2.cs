using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using OsuApi.V2.Clients.Beatmaps;
using OsuApi.V2.Clients.Beatmapsets;
using OsuApi.V2.Clients.Rankings;
using OsuApi.V2.Clients.Scores;
using OsuApi.V2.Clients.Users;
using OsuApi.V2.Extensions;
using OsuApi.V2.Extensions.Types;
using OsuApi.V2.Utilities.GrantAccessUtility;

// ReSharper disable InconsistentNaming

namespace OsuApi.V2;

public class ApiV2 : Api
{
    /// <summary>
    ///     Base url address of api endpoint
    /// </summary>
    public static readonly string ApiMainFunctionsBaseAddress = GetBaseUrl(ApiVersion.ApiV2);

    /// <summary>
    ///     Client id and client secret for authenticating in api
    /// </summary>
    public readonly ApiConfiguration ApiConfiguration;

    /// <summary>
    ///     Currently using api response version
    /// </summary>
    public readonly ApiResponseVersion ApiResponseVersion;

    /// <summary>
    ///     Creates an instance of ApiV2. This method also executes <see cref="Initialize" />
    /// </summary>
    /// <param name="client_id">Your client_id for accessing osu!api v2</param>
    /// <param name="client_secret">Your client_secret for accessing osu!api v2</param>
    /// <param name="apiResponseVersion">Response version of api v2</param>
    /// <param name="httpClient">Used http client for api related requests</param>
    public ApiV2(int client_id, string client_secret, HttpClient? httpClient = null,
        ApiResponseVersion apiResponseVersion = ApiResponseVersion.V20240529)
    {
        HttpClient = httpClient ?? new HttpClient();
        ApiResponseVersion = apiResponseVersion;

        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            string? logLevel = Environment.GetEnvironmentVariable("Logger.LogLevel");
            builder.SetMinimumLevel(logLevel == "Debug" ? LogLevel.Debug: LogLevel.Information);
        });
        Logger = loggerFactory.CreateLogger(nameof(ApiV2));

        ApiConfiguration = new ApiConfiguration(client_id, client_secret);
        SetDefaultRequestHeaders();
        Initialize().Wait();

        Scores = new ScoresClient(this);
        Users = new UsersClient(this);
        Beatmaps = new BeatmapsClient(this);
        Beatmapsets = new BeatmapsetsClient(this);
        Rankings = new RankingsClient(this);
    }

    /// <summary>
    ///     Scores api endpoint
    /// </summary>
    public ScoresClient Scores { get; init; }

    /// <summary>
    ///     Users api endpoint
    /// </summary>
    public UsersClient Users { get; init; }

    /// <summary>
    ///     Beatmaps api endpoint
    /// </summary>
    public BeatmapsClient Beatmaps { get; init; }

    /// <summary>
    ///     Beatmapsets api endpoint
    /// </summary>
    public BeatmapsetsClient Beatmapsets { get; init; }

    /// <summary>
    ///     Rankings api endpoint
    /// </summary>
    public RankingsClient Rankings { get; init; }

    /// <summary>
    ///     Default console logger
    /// </summary>
    public sealed override ILogger Logger { get; set; }

    /// <summary>
    ///     HttpClient for api calls
    /// </summary>
    protected sealed override HttpClient? HttpClient { get; set; }

    /// <summary>
    ///     Utility for getting an access token in order to access api
    /// </summary>
    private GrantAccess? GrantAccess { get; set; }

    /// <summary>
    ///     Checks if this instance is ready to interact with api
    /// </summary>
    public bool IsInitialized { get; set; }

    /// <summary>
    ///     Indicates current api version
    /// </summary>
    /// <returns>ApiVersion</returns>
    public override ApiVersion CurrentApiVersion()
    {
        return ApiVersion.ApiV2;
    }

    protected sealed override async Task Initialize()
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
        HttpClient.DefaultRequestHeaders.Add("x-api-version", $"{(int)ApiResponseVersion}");
    }

    /// <summary>
    ///     Makes an HTTP request with given QueryParameters
    /// </summary>
    /// <typeparam name="T">Response type to be decoded from json</typeparam>
    /// <param name="url">Url for current http request</param>
    /// <param name="httpMethod">HTTP Method to use.</param>
    /// <param name="queryParameters">Query parameter to pass into url. Can be null, if none query parameters specified</param>
    /// <param name="content">Body content of the request</param>
    /// <param name="updateTokenIfNeeded">Should the token be updated before the request if it's outdated</param>
    /// <param name="setAuthorizationHeader">Should the auth header be set</param>
    /// <returns>A response of the type T</returns>
    public override async Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod,
        QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true,
        bool setAuthorizationHeader = true, CancellationToken? cancellationToken = null) where T : class
    {
        cancellationToken ??= CancellationToken.None;

        if (GrantAccess == null) throw new Exception();
        if (HttpClient == null) throw new Exception();

        if (updateTokenIfNeeded) await GrantAccess.UpdateTokenIfNeeded();
        cancellationToken?.ThrowIfCancellationRequested();

        using var httpRequest = new HttpRequestMessage(httpMethod, url);
        httpRequest.Content = content;
        if (setAuthorizationHeader)
            httpRequest.SetAuthorizationHeader($"{GrantAccess.GetTokenType()} {GrantAccess.GetAccessToken()}");
        if (queryParameters != null)
            httpRequest.SetQueryParameters(queryParameters.QueryProperties,
                queryParameters.ParametersClassInstance);
        cancellationToken?.ThrowIfCancellationRequested();

        var httpResponse = await HttpClient.SendAsync(httpRequest, cancellationToken!.Value).ConfigureAwait(false);
        if (!httpResponse.IsSuccessStatusCode)
        {
            if (httpResponse.StatusCode == HttpStatusCode.NotFound) return null;

            throw new HttpRequestException(
                $"Request failed with status code {(int)httpResponse.StatusCode} ({httpResponse.StatusCode}).");
        }

        Logger.LogDebug("\n\n\n\n" + await httpResponse.Content.ReadAsStringAsync(cancellationToken!.Value));

        return await httpResponse.Content.ReadFromJsonAsync<T>(cancellationToken!.Value);
    }

    #region Dispose

    private bool _disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                if (HttpClient != null) HttpClient.Dispose();
                if (GrantAccess != null) GrantAccess.Dispose();
            }

            _disposedValue = true;
        }
    }

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}