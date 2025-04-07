using OsuApi.Core.V2;
using OsuApi.Core.V2.Beatmaps.Models.HttpIO;
using OsuApi.Core.V2.Scores.Models;
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
            var configuration = JsonSerializer.Deserialize<Configuration>(File.ReadAllText(path));
            if (configuration == null) throw new Exception("Bad appsettings.json");

            // api v2
            var api = new ApiV2(configuration.client_id, configuration.client_secret);

            var q1 = new GetUserBeatmapScoreQueryParameters
            {

            };
            var r1 = await api.Beatmaps.GetUserBeatmapScore(2060305, 15319810, q1);

            var q2 = new LookupBeatmapQueryParameters
            {
                Id = 4921872,
            };
            var r2 = await api.Beatmaps.LookupBeatmap(q2);

            var q3 = new GetBeatmapAttributesRequest
            {
                Ruleset = Ruleset.Osu,
                Mods = new Mod[] { new Mod { Acronym = "DT" }, new Mod { Acronym = "HD" } },
            };
            var r3 = await api.Beatmaps.GetBeatmapAttributes(4921872, q3);

            Console.WriteLine(JsonSerializer.Serialize(r2, new JsonSerializerOptions() { WriteIndented = true }));
            Console.WriteLine(JsonSerializer.Serialize(r3, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}
