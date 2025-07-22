using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record NominationsSummary
    {
        [JsonPropertyName("current")]
        public int? Current { get; init; }

        [JsonPropertyName("eligible_main_rulesets")]
        public List<string>? EligibleMainRulesets { get; init; }

        [JsonPropertyName("required_meta")]
        public RequiredMeta? RequiredMeta { get; init; }
    }
}
