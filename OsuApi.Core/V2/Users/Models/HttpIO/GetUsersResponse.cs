using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUsersResponse
    {
        [JsonPropertyName("users")]
        public required User[] Users { get; set; }
    }
}
