using OsuApi.V2;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using OsuApi.V2.Models;
using OsuApi.Examples;
using OsuApi.V2.Users.Models;

// get config from json
string path = "appsettings.json";
if (!File.Exists(path))
    throw new Exception(
        "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
if (configuration == null) throw new Exception("Bad appsettings.json");

// api v2
var api = new ApiV2(configuration.ClientId, configuration.ClientSecret);
//var a1 = await api.Users.GetUser("@Shoukko", new());
//var a2 = await api.Beatmaps.GetUserBeatmapScores(970048, 15319810, new());
var a3 = await api.Rankings.GetRanking(Ruleset.Osu, RankingType.Performance, new(){Country = "uz"});
var a4 = await api.Users.GetUserScores(15319810, ScoreType.Recent, new() {IncludeFails = 1});
var a = 1;