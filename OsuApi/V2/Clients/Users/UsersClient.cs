using OsuApi.V2.Clients.Users.HttpIO;
using OsuApi.V2.Extensions;
using OsuApi.V2.Extensions.Types;
using OsuApi.V2.Models;
using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Users;

public sealed class UsersClient : Client
{
    public UsersClient(Api api) : base(api)
    {
    }

    /// <summary>
    ///     Similar to <see cref="GetUser(string, GetUserQueryParameters, string?)" /> but with authenticated user (token
    ///     owner) as user id.
    /// </summary>
    /// <param name="mode"><see cref="Ruleset" /> - User default mode will be used if not specified.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetOwnDataResponse?> GetOwnData(string? mode = null, CancellationToken? cancellationToken = null)
    {
        ApiUtility.ThrowIfParameterValueIsNotOfType(mode, typeof(Ruleset));

        var response = await Api.MakeRequestAsync<UserExtend>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/me/{mode ?? ""}",
            HttpMethod.Get,
            null,
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetOwnDataResponse { UserExtend = response };
    }

    /// <summary>
    ///     Returns kudosu history.
    /// </summary>
    /// <param name="user">Id of the user.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserKudosuResponse?> GetUserKudosu(long user, CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<KudosuHistory[]>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/kudosu",
            HttpMethod.Get,
            null,
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserKudosuResponse { KudosuHistories = response };
    }

    /// <summary>
    ///     This endpoint returns the scores of specified user.
    /// </summary>
    /// <param name="userId">Id of the user.</param>
    /// <param name="scoreType">
    ///     <see cref="ScoreType" />
    /// </param>
    /// <param name="parameters">Query parameters</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserScoresResponse?> GetUserScores(long userId, string scoreType,
        GetUserScoreQueryParameters parameters, CancellationToken? cancellationToken = null)
    {
        ApiUtility.ThrowIfParameterValueIsNotOfType(scoreType, typeof(ScoreType));

        var response = await Api.MakeRequestAsync<Score[]>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{userId}/scores/{scoreType}",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserScoresResponse { Scores = response };
    }

    /// <summary>
    ///     Returns the beatmaps of specified user. Beatmaps type is most_played
    /// </summary>
    /// <param name="user">Id of the user.</param>
    /// <param name="parameters">Query parameters</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserBeatmapsResponse?> GetUserBeatmaps_MostPlayed(long user,
        GetUserBeatmapsQueryParameters parameters, CancellationToken? cancellationToken = null)
    {
        var type = "most_played";
        var response = await Api.MakeRequestAsync<BeatmapPlaycount[]>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/beatmapsets/{type}",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserBeatmapsResponse { BeatmapPlaycounts = response };
    }

    /// <summary>
    ///     Returns the beatmaps of specified user.
    /// </summary>
    /// <param name="user">Id of the user.</param>
    /// <param name="type">See <see cref="BeatmapType" /></param>
    /// <param name="parameters">Query parameters</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserBeatmapsResponse?> GetUserBeatmaps(long user, string type,
        GetUserBeatmapsQueryParameters parameters, CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<BeatmapsetExtended[]>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/beatmapsets/{type}",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserBeatmapsResponse { BeatmapsetExtendeds = response };
    }

    /// <summary>
    ///     Returns recent activity.
    /// </summary>
    /// <param name="user">Id of the user.</param>
    /// <param name="parameters">Query parameters</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserRecentActivityResponse?> GetUserRecentActivity(long user,
        GetUserRecentActivityQueryParameters parameters, CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<Event[]>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/recent_activity",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserRecentActivityResponse { Events = response };
    }

    /// <summary>
    ///     This endpoint returns the detail of specified user.
    /// </summary>
    /// <param name="user">Id or @-prefixed username of the user. Previous usernames are also checked in some cases.</param>
    /// <param name="parameters">Query parameters</param>
    /// <param name="mode"><see cref="Ruleset" /> - User default mode will be used if not specified.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUserResponse?> GetUser(string user, GetUserQueryParameters parameters, string? mode = null,
        CancellationToken? cancellationToken = null)
    {
        ApiUtility.ThrowIfParameterValueIsNotOfType(mode, typeof(Ruleset));

        var response = await Api.MakeRequestAsync<UserExtend>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/{mode ?? ""}",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return new GetUserResponse { UserExtend = response };
    }

    /// <summary>
    ///     Returns list of users.
    /// </summary>
    /// <param name="parameters">Query parameters</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<GetUsersResponse?> GetUsers(GetUsersQueryParameters parameters,
        CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<GetUsersResponse>(
            ApiV2.ApiMainFunctionsBaseAddress + "/users",
            HttpMethod.Get,
            new QueryParameters(parameters.GetType().GetProperties(), parameters),
            cancellationToken: cancellationToken
        );
        if (response is null) return null;

        return response;
    }
}