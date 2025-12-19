using OsuApi.Examples;
using OsuApi.V2;
using OsuApi.V2.Clients.Scores.HttpIO;
using OsuApi.V2.Models;
using OsuApi.V2.Users.Models;
using System.Text.Json;

// get config from json
var path = "appsettings.json";
if (!File.Exists(path))
    throw new Exception(
        "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
if (configuration == null) throw new Exception("Bad appsettings.json");

var api = new ApiV2(configuration.ClientId, configuration.ClientSecret);

var a1 = await api.Scores.GetScores(new ScoresQueryParameters { CursorString = null, Ruleset = Ruleset.Fruits });
Console.WriteLine("Done");

/*
 * aim 4.54
 * speed 2.90
 * stars: 8.03
 */