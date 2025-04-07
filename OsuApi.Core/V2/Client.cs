namespace OsuApi.Core.V2
{
    public abstract class Client
    {
        protected Api Api;
        public Client(Api api) => (Api) = (api);
    }
}
