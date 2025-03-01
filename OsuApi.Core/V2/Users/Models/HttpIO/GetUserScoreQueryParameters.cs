using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUserScoreQueryParameters
    {
        [QueryParameter("legacy_only")]
        public string? LegacyOnly { get; set; }

        [QueryParameter("include_fails")]
        public string? IncludeFails { get; set; }

        [QueryParameter("mode")]
        public string? Mode { get; set; }

        [QueryParameter("limit")]
        public int? Limit { get; set; }

        [QueryParameter("offset")]
        public string? Offset { get; set; }
    }
}
