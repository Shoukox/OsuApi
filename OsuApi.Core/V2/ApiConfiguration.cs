using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuApi.Core.V2
{
    public record ApiConfiguration(int ClientId, string ClientSecret);
}