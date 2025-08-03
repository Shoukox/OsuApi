using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models;

public record Level
{
    /// <summary>
    ///     Current level.
    /// </summary>
    [JsonPropertyName("current")]
    public int? Current { get; set; }

    /// <summary>
    ///     Progress to next level.
    /// </summary>
    [JsonPropertyName("progress")]
    public int? Progress { get; set; }
}