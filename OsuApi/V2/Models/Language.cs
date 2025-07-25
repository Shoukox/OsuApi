﻿using System.Text.Json.Serialization;

namespace OsuApi.V2.Users.Models
{
    public record Language
    {
        [JsonPropertyName("id")]
        public int? Id { get; init; }

        [JsonPropertyName("name")]
        public string? Name { get; init; }
    }
}
