using OsuApi.Core.V2.Extensions;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.Scores.Models;
using OsuApi.Core.V2.Users.Models;
using OsuApi.Core.V2.Users.Models.HttpIO;

namespace OsuApi.Core.V2.Users
{
    public sealed class UsersClient : Client
    {
        public UsersClient(Api api) : base(api) { }

        /// <summary>
        /// Similar to <see cref="GetUser(string, GetUserQueryParameters, string?)"/> but with authenticated user (token owner) as user id.
        /// </summary>
        /// <param name="mode"><see cref="Ruleset"/> - User default mode will be used if not specified.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetOwnDataResponse> GetOwnData(string? mode = null)
        {
            ApiUtility.ThrowIfParameterValueIsNotOfType(mode, typeof(Ruleset));

            var response = await Api.MakeRequestAsync<UserExtend>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/me/{mode ?? ""}",
                    HttpMethod.Get,
                    queryParameters: null
            );
            if (response == default) throw new Exception();

            return new GetOwnDataResponse { UserExtend = response };
        }

        /// <summary>
        /// Returns kudosu history.
        /// </summary>
        /// <param name="user">Id of the user.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserKudosuResponse> GetUserKudosu(long user)
        {
            var response = await Api.MakeRequestAsync<KudosuHistory[]>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/kudosu",
                    HttpMethod.Get,
                    queryParameters: null
            );
            if (response == default) throw new Exception();

            return new GetUserKudosuResponse { KudosuHistories = response };
        }

        /// <summary>
        /// This endpoint returns the scores of specified user.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <param name="scoreType"><see cref="ScoreType"/></param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserScoreResponse> GetUserScores(long userId, string scoreType, GetUserScoreQueryParameters parameters)
        {
            ApiUtility.ThrowIfParameterValueIsNotOfType(scoreType, typeof(Ruleset));

            var response = await Api.MakeRequestAsync<Score[]>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{userId}/scores/{scoreType}",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserScoreResponse { Scores = response };
        }

        /// <summary>
        /// Returns the beatmaps of specified user. Beatmaps type is most_played
        /// </summary>
        /// <param name="user">Id of the user.</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserBeatmapsResponse> GetUserBeatmaps_MostPlayed(long user, GetUserBeatmapsQueryParameters parameters)
        {
            string type = "most_played";
            var response = await Api.MakeRequestAsync<BeatmapPlaycount[]>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/beatmapsets/{type}",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserBeatmapsResponse { BeatmapPlaycounts = response };
        }

        /// <summary>
        /// Returns the beatmaps of specified user.
        /// </summary>
        /// <param name="user">Id of the user.</param>
        /// <param name="type">See <see cref="BeatmapType"/></param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserBeatmapsResponse> GetUserBeatmaps(long user, string type, GetUserBeatmapsQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<BeatmapsetExtended[]>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/beatmapsets/{type}",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserBeatmapsResponse { BeatmapsetExtendeds = response };

        }

        /// <summary>
        /// Returns recent activity.
        /// </summary>
        /// <param name="user">Id of the user.</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserRecentActivityResponse> GetUserRecentActivity(long user, GetUserRecentActivityQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<Event[]>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/recent_activity",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserRecentActivityResponse { Events = response };
        }

        /// <summary>
        /// This endpoint returns the detail of specified user.
        /// </summary>
        /// <param name="user">Id or @-prefixed username of the user. Previous usernames are also checked in some cases.</param>
        /// <param name="parameters">Query parameters</param>
        /// <param name="mode"><see cref="Ruleset"/> - User default mode will be used if not specified.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUserResponse> GetUser(string user, GetUserQueryParameters parameters, string? mode = null)
        {
            ApiUtility.ThrowIfParameterValueIsNotOfType(mode, typeof(Ruleset));
            
            var response = await Api.MakeRequestAsync<UserExtend>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users/{user}/{mode ?? ""}",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return new GetUserResponse { UserExtend = response };
        }

        /// <summary>
        /// Returns list of users.
        /// </summary>
        /// <param name="parameters">Query parameters</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetUsersResponse> GetUsers(GetUsersQueryParameters parameters)
        {
            var response = await Api.MakeRequestAsync<GetUsersResponse>(
                    url: ApiV2.ApiMainFunctionsBaseAddress + $"/users",
                    HttpMethod.Get,
                    queryParameters: new QueryParameters(parameters.GetType().GetProperties(), parameters)
            );
            if (response == default) throw new Exception();

            return response;
        }
    }
}
