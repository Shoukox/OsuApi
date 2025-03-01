using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    /// <summary>
    /// Describes a Group membership of a User. <br/>
    /// It contains all of the attributes of the Group, in addition to what is listed here.
    /// </summary>
    public record UserGroup
    {
        /// <summary>
        /// <see cref="Scores.Models.Ruleset">Rulesets</see> associated with this membership (null if has_playmodes is unset).
        /// </summary>
        [JsonPropertyName("playmodes")]
        public string[]? Playmodes { get; set; }
    }
}
