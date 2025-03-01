using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUserRecentActivityQueryParameters
    {
        [QueryParameter("limit")]
        public int? Limit { get; set; }

        [QueryParameter("offset")]
        public string? Offset { get; set; }
    }
}
