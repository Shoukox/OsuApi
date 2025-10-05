using System.Text.Json;
using OsuApi.Examples;

// get config from json
var path = "appsettings.json";
if (!File.Exists(path))
    throw new Exception(
        "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
var configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
if (configuration == null) throw new Exception("Bad appsettings.json");

// api v2
//var api = new ApiV2(configuration.ClientId, configuration.ClientSecret);
//var a1 = await api.Users.GetUser("@Shoukko", new GetUserQueryParameters());