using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUserQueryParameters
    {
        [QueryParameter("key")]
        public string? Key { get; set; }
    }
}
