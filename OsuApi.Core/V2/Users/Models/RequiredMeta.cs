using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Users.Models
{
    public record RequiredMeta
    {
        [JsonPropertyName("main_ruleset")]
        public int? MainRuleset { get; init; }

        [JsonPropertyName("non_main_ruleset")]
        public int? NonMainRuleset { get; init; }
    }
}
