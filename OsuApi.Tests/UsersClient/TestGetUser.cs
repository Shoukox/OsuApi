using System.Text.Json;
using NUnit.Framework;
using OsuApi.V2;
using OsuApi.Tests.Types;

namespace OsuApi.Tests.UsersClient;

[TestFixture]
public class TestGetUser
{
    //private Api _apiV1; //todo
    private ApiV2 _apiV2 = null!;

    [SetUp]
    public void SetUp()
    {
        // get config from json
        string path = "appsettings.json";
        if (!File.Exists(path))
            throw new Exception(
                "You should firstly create an appsettings.json and pass your client_id and client_secret into it!");
        ApiV2Configuration? configuration = JsonSerializer.Deserialize<ApiV2Configuration>(File.ReadAllText(path));
        if (configuration == null) throw new Exception("Bad appsettings.json");

        _apiV2 = new ApiV2(configuration.ClientId, configuration.ClientSecret);
    }

    [TestCase(15319810, "Shoukko")]
    public void TestApiV2GetUser(long userId, string expectedUsername)
    {
        Assert.That(_apiV2.Users.GetUser(userId.ToString(), new()).Result!.UserExtend!.Username,
            Is.EqualTo(expectedUsername));
    }

    [TearDown]
    public void TearDown()
    {
        //_apiV1.Dispose();
        _apiV2.Dispose();
    }
}