using System.Text.Json.Serialization;

namespace OsuApi.Examples
{
    public record ApiV2Configuration
    {
        [JsonPropertyName("client_id")] public int ClientId { get; set; } = -1;
        [JsonPropertyName("client_secret")] public string ClientSecret { get; set; } = "";
    }
}
