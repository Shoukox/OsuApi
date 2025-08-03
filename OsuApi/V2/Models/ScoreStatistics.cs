using System.Text.Json.Serialization;

namespace OsuApi.V2.Models;

public record ScoreStatistics
{
    [JsonPropertyName("perfect")] public int Perfect { get; set; }

    [JsonPropertyName("great")] public int Great { get; set; }

    [JsonPropertyName("good")] public int Good { get; set; }

    [JsonPropertyName("ok")] public int Ok { get; set; }

    [JsonPropertyName("meh")] public int Meh { get; set; }

    [JsonPropertyName("miss")] public int Miss { get; set; }

    [JsonPropertyName("ignore_hit")] public int IgnoreHit { get; set; }

    [JsonPropertyName("ignore_miss")] public int IgnoreMiss { get; set; }

    [JsonPropertyName("large_bonus")] public int LargeBonus { get; set; }

    [JsonPropertyName("small_bonus")] public int SmallBonus { get; set; }

    [JsonPropertyName("slider_tail_hit")] public int SliderTailHit { get; set; }

    [JsonPropertyName("large_tick_hit")] public int LargeTickHit { get; set; }

    [JsonPropertyName("small_tick_hit")] public int SmallTickHit { get; set; }

    [JsonPropertyName("large_tick_miss")] public int LargeTickMiss { get; set; }

    [JsonPropertyName("small_tick_miss")] public int SmallTickMiss { get; set; }

    [JsonPropertyName("legacy_combo_increase")]
    public int LegacyComboIncrease { get; set; }
}