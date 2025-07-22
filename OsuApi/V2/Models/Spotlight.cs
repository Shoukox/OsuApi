using System.Text.Json.Serialization;
using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Models;

public sealed record Spotlight
{
    [JsonPropertyName("end_date")]
    public Timestamp? EndDate { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("mode_specific")]
    public bool? ModeSpecific { get; set; }

    [JsonPropertyName("participant_count")]
    public int? ParticipantCount { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("start_date")]
    public Timestamp? StartDate { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}