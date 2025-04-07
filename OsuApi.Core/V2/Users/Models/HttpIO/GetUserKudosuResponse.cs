namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserKudosuResponse
    {
        public required KudosuHistory[] KudosuHistories { get; set; }
    }
}
