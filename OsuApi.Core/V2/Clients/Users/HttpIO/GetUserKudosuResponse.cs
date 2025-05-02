using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetUserKudosuResponse
    {
        public required KudosuHistory[] KudosuHistories { get; set; }
    }
}
