using System.Text.Json;
using OsuApi.Examples;
using OsuApi.V2;
using OsuApi.V2.Clients.Rankings.HttpIO;
using OsuApi.V2.Clients.Users.HttpIO;
using OsuApi.V2.Models;
using OsuApi.V2.Users.Models;

// get config from json
var path = "appsettings.json";
if (!File.Exists(path))
    throw new Exception(
        "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
if (configuration == null) throw new Exception("Bad appsettings.json");

// api v2
var api = new ApiV2(configuration.ClientId, configuration.ClientSecret);
var a1 = await api.Users.GetUser("@Shoukko", new());
var a2 = await api.Users.GetUserScores(37072030, ScoreType.Recent, new() { IncludeFails = 1, Limit = 100 });
var a = 1;