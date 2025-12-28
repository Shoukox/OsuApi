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
//var a1 = await api.Users.GetUser("@Shoukko", new());
//var a2 = await api.Beatmaps.GetUserBeatmapScores(970048, 15319810, new());
//var a3 = await api.Users.GetUserScores(15319810, ScoreType.Recent, new() { IncludeFails = 1, Limit = 1, Mode = Ruleset.Osu });
var a4 = await api.Scores.DownloadScoreReplay("5407790548");

using var fileStream = File.Create("replay.osr");
a4.Seek(0, SeekOrigin.Begin);
a4.CopyTo(fileStream);
fileStream.Close();

Console.WriteLine();