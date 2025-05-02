using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public class Team
    {
        [JsonPropertyName("flag_url")]
        public string? FlagUrl { get; set; }

        /// <summary>
        /// Not null
        /// </summary>
        [JsonPropertyName("id")]
        [NotNull]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("short_name")]
        public string? ShortName { get; set; }
    }
}
