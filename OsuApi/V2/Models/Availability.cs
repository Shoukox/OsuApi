using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Availability
    {
        [JsonPropertyName("download_disabled")]
        public bool? DownloadDisabled { get; init; }

        [JsonPropertyName("more_information")]
        public string? MoreInformation { get; init; }
    }
}
