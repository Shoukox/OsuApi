namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserRecentActivityResponse
    {
        public required Event[] Events { get; set; }
    }
}
