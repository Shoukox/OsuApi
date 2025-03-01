using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Users.Models.HttpIO
{
    public class GetUsersQueryParameters
    {
        [QueryParameter("ids[]")]
        public string[]? Ids { get; set; }

        [QueryParameter("include_variant_statistics")]
        public bool? IncludeVariantStatistics { get; set; }
    }
}
