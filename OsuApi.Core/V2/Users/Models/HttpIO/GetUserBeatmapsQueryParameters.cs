using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserBeatmapsQueryParameters
    {
        [QueryParameter("limit")]
        public int? Limit { get; set; }

        [QueryParameter("offset")]
        public string? Offset { get; set; }
    }
}
