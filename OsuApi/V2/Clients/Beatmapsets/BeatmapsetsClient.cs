using OsuApi.V2.Users.Models;

namespace OsuApi.V2.Clients.Beatmapsets;

public class BeatmapsetsClient : Client
{
    public BeatmapsetsClient(Api api) : base(api)
    {
    }

    public async Task<BeatmapsetExtended> GetBeatmapset(int beatmapset, CancellationToken? cancellationToken = null)
    {
        var response = await Api.MakeRequestAsync<BeatmapsetExtended>(
            ApiV2.ApiMainFunctionsBaseAddress + $"/beatmapsets/{beatmapset}",
            HttpMethod.Get,
            cancellationToken: cancellationToken
        );
        if (response == default) throw new Exception();

        return response;
    }
}