using OsuApi.Core.V2.Extensions;
using OsuApi.Core.V2.Extensions.Types;
using OsuApi.Core.V2.GrantAccessUtility;
using System.Net.Http.Json;

namespace OsuApi.Core.V2
{
    public abstract class Client
    {
        protected Api Api;
        public Client(Api api) => (Api) = (api);
    }
}
