using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Users.HttpIO;

public record GetUserResponse
{
    public UserExtend? UserExtend { get; set; }
}