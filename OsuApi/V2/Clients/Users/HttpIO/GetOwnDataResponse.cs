using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Users.HttpIO
{
    public record GetOwnDataResponse
    {
        public UserExtend? UserExtend { get; set; }
    }
}
