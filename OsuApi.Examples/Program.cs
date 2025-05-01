using OsuApi.Core.V2;
using OsuApi.Core.V2.Beatmaps.Models.HttpIO;
using OsuApi.Core.V2.Scores.Models;
using OsuApi.Core.V2.Users.Models;
using System.Text.Json;

namespace OsuApi.Examples
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            // get config from json
            string path = "appsettings.json";
            if (!File.Exists(path)) throw new Exception("You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
            var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
            if (configuration == null) throw new Exception("Bad appsettings.json");

            // api v2
            var api = new ApiV2(configuration.client_id, configuration.client_secret);
            //var a1 = await api.Users.GetUser("@Shoukko", new());
            //var a2 = await api.Beatmaps.GetUserBeatmapScores(970048, 15319810, new());
            //var a3 = await api.Users.GetUserScores(15319810, ScoreType.Recent, new() { IncludeFails = 1, Limit = 1, Mode = Ruleset.Osu });
            var a4 = await api.Beatmapsets.GetBeatmapset(2363330);
        }
    }
}
