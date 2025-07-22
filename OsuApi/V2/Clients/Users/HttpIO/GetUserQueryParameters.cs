using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Clients.Users.HttpIO
{
    public record GetUserQueryParameters
    {
        /// <summary>
        /// Type of user passed in url parameter. 
        /// Can be either id or username to limit lookup by their respective type. 
        /// Passing empty or invalid value will result in id lookup followed by username lookup if not found. 
        /// This parameter has been deprecated. Prefix user parameter with @ instead to lookup by username.
        /// </summary>
        [QueryParameter("key")]
        public string? Key { get; set; }
    }
}
