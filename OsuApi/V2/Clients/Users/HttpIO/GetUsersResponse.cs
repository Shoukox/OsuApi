using System.Text.Json.Serialization;
using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Users.HttpIO
{
    public record GetUsersResponse
    {
        [JsonPropertyName("users")]
        public required User[] Users { get; set; }
    }
}
