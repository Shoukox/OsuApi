using OsuApi.Core.V2.Users.Models;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetUsersResponse
    {
        [JsonPropertyName("users")]
        public required User[] Users { get; set; }
    }
}
