using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUsersResponse
    {
        [JsonPropertyName("users")]
        public required User[] Users { get; set; }
    }
}
