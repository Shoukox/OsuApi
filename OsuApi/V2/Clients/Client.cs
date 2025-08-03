namespace OsuApi.V2.Clients;

public abstract class Client
{
    protected Api Api;

    public Client(Api api)
    {
        Api = api;
    }
}