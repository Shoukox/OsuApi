using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.GrantAccessUtility.Models.HttpIO
{
    public class ClientCredentialsGrantResponse
    {
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
    }
}
