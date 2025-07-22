using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Users.HttpIO
{
    public record GetUserRecentActivityQueryParameters
    {
        [QueryParameter("limit")]
        public int? Limit { get; set; }

        [QueryParameter("offset")]
        public string? Offset { get; set; }
    }
}
