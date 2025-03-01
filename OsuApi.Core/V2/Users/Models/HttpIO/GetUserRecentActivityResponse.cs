namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUserRecentActivityResponse
    {
        public required Event[] Events { get; set; }
    }
}
