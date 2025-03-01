using OsuApi.Core;
using OsuApi.Core.V2;
using OsuApi.Core.V2.Scores.Models;
using OsuApi.Core.V2.Scores.Models.HttpIO;
using OsuApi.Core.V2.Users.Models;
using OsuApi.Core.V2.Users.Models.HttpIO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OsuApi.Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("appsettings.json"));
            if (configuration == null) throw new Exception("Bad appsettings.json");

            var api = (ApiV2)Api.CreateV2(configuration.client_id, configuration.client_secret);

            var scoresRequest = new ScoresQueryParameters()
            {
                Ruleset = Ruleset.Osu,
                CursorString = null
            };
            var a1 = api.Score.GetScores(scoresRequest).Result;

            var getUserQueryParameters = new GetUserQueryParameters()
            {

            };
            var a2 = api.Users.GetUser("Shoukko", getUserQueryParameters).Result;

            var getUserScoreQueryParameters = new GetUserScoreQueryParameters()
            {
                Limit = 5
            };
            var a3 = api.Users.GetUserScores(a2.UserExtend.Id!.Value, ScoreType.Best, getUserScoreQueryParameters).Result;
            var a4 = api.Users.GetUserKudosu(a2.UserExtend.Id!.Value).Result;

            var getUserBeatmapsQueryParameters = new GetUserBeatmapsQueryParameters()
            {
                Limit = 10,
                Offset = "0"
            };
            var a5 = api.Users.GetUserBeatmaps_MostPlayed(a2.UserExtend.Id!.Value, getUserBeatmapsQueryParameters).Result;
            var a6 = api.Users.GetUserBeatmaps(a2.UserExtend.Id!.Value, "favourite", getUserBeatmapsQueryParameters).Result;

            var getUserRecentActivityQueryParameters = new GetUserRecentActivityQueryParameters()
            {
                Limit = 50,
                Offset = "0"
            };
            var a7 = api.Users.GetUserRecentActivity(a2.UserExtend.Id!.Value, getUserRecentActivityQueryParameters).Result;

            var getUsersQueryParameters = new GetUsersQueryParameters()
            {
                IncludeVariantStatistics = true,
                Ids = ["7562902", "4504101", "15319810", "12955763", "17489298"]
            };
            var a8 = api.Users.GetUsers(getUsersQueryParameters).Result;
        }
    }
}
