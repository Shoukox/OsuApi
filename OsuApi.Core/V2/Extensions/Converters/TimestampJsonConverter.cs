using OsuApi.Core.V2.Users.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OsuApi.Core.V2.Extensions.Converters
{
    class TimestampJsonConverter : JsonConverter<Timestamp>
    {
        public override Timestamp Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Timestamp() { Value = reader.GetString() };
        }

        public override void Write(Utf8JsonWriter writer, Timestamp value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
