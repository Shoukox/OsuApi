using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OsuApi.Core.V2.Users.Models
{
    public record Hype
    {
        [JsonPropertyName("current")]
        public int? Current { get; init; }

        [JsonPropertyName("required")]
        public int? Required { get; init; }
    }
}
