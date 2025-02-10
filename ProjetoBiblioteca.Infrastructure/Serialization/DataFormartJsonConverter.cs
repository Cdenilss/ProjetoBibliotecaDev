using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjetoBiblioteca.Infrastructure.Serialization
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    namespace ProjetoBiblioteca.Infrastructure.Serialization
    {
        public class DateFormatJsonConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException("Formato de data inválido.");
                }

                var dateString = reader.GetString();

                if (DateTime.TryParse(dateString, out DateTime date))
                {
                    return date;
                }

                throw new JsonException("Formato de data inválido.");
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                // Formato dd-MM-yy
                writer.WriteStringValue(value.ToString("dd-MM-yy"));
            }
        }
    }

}