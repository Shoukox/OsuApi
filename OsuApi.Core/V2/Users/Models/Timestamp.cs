namespace OsuApi.Core.V2.Users.Models
{
    /// <summary>
    /// Timestamp string in ISO 8601 format.
    /// <example>
    /// <code>Example: 2020-01-01T00:00:00+00:00</code>
    /// </example>
    /// </summary>
    public record Timestamp
    {
        public string? Value { get; set; }
    }
}
