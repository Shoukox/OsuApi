using OsuApi.Core.V2;
using OsuApi.Core.V2.Extensions.Types;

namespace OsuApi.Core
{
    public abstract class Api : IRequestMaker, IDisposable
    {
        protected abstract HttpClient? HttpClient { get; set; }
        protected abstract Task Initialize();

        protected static string GetBaseUrl(ApiVersion apiVersion)
        {
            return apiVersion switch
            {
                ApiVersion.ApiV1 => "https://osu.ppy.sh/api/v1",
                ApiVersion.ApiV2 => "https://osu.ppy.sh/api/v2",
                _ => throw new NotImplementedException()
            };
        }

        public abstract Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true) where T : class;
        public abstract void Dispose();
    }
}
