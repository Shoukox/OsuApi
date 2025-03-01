using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.GrantAccessUtility.Models.HttpIO
{
    class ClientCredentialsGrantRequest
    {
        [JsonPropertyName("client_id")]
        public required int ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public required string ClientSecret { get; set; }

        [JsonPropertyName("grant_type")]
        public required string GrantType { get; set; }

        [JsonPropertyName("scope")]
        public required string Scope { get; set; }
    }
}
