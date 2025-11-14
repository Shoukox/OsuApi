using System.Text.Json;
using OsuApi.Examples;
using OsuApi.V2;
using OsuApi.V2.Models;
using OsuApi.V2.Users.Models;

// get config from json
var path = "appsettings.json";
if (!File.Exists(path))
    throw new Exception(
        "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
if (configuration == null) throw new Exception("Bad appsettings.json");

var api = new ApiV2(configuration.ClientId, configuration.ClientSecret);
var a1 = await api.Users.GetUserScores(15319810, ScoreType.Best, new() { Limit = 10 });
var a2 = await api.Beatmaps.GetBeatmapAttributes(4864071, new() { Mods = [new Mod() { Acronym = "DT"}] });
Console.WriteLine("Done");

/*
 * aim 4.54
 * speed 2.90
 * stars: 8.03
 */