namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public record GetUserResponse
    {
        public UserExtend? UserExtend { get; set; }
    }
}
