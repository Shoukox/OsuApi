using OsuApi.Core.V2.Users.Models;

namespace OsuApi.Core.V2.Clients.Users.HttpIO
{
    public record GetOwnDataResponse
    {
        public UserExtend? UserExtend { get; set; }
    }
}
