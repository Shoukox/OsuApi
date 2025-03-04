using OsuApi.Core.V2.Extensions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2
{
    interface IRequestMaker
    {
        public Task<T?> MakeRequestAsync<T>(string url, HttpMethod httpMethod, QueryParameters? queryParameters = null, HttpContent? content = null, bool updateTokenIfNeeded = true, bool setAuthorizationHeader = true) where T : class;
    }
}
