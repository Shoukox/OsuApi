using OsuApi.Core.V2;

namespace OsuApi.Core
{
    public abstract class Api : IDisposable
    {
        protected abstract HttpClient? HttpClient { get; set; }
        protected abstract void GrantAccessFunction();

        //protected abstract Client UserClient { get; set; }
        //protected abstract Client ScoreClient { get; set; }

        public static Api CreateV1() => throw new NotImplementedException();
        public static Api CreateV2(int client_id, string client_secret) => new ApiV2(client_id, client_secret);

        public abstract void Dispose();

    }
}
