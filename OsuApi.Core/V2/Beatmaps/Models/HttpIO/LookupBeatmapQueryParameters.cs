using OsuApi.Core.V2.Extensions.Attributes;

namespace OsuApi.Core.V2.Beatmaps.Models.HttpIO
{
    public class LookupBeatmapQueryParameters
    {
        /// <summary>
        /// A beatmap checksum.
        /// </summary>
        [QueryParameter("checksum")]
        public string? Checksum { get; set; }

        /// <summary>
        /// A filename to lookup.
        /// </summary>
        [QueryParameter("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// A beatmap ID to lookup.
        /// </summary>
        [QueryParameter("id")]
        public long? Id { get; set; }
    }
}
