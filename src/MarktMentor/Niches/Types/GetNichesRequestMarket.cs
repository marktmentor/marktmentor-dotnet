using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(GetNichesRequestMarket.GetNichesRequestMarketSerializer))]
[Serializable]
public readonly record struct GetNichesRequestMarket : IStringEnum
{
    public static readonly GetNichesRequestMarket Nl = new(Values.Nl);

    public static readonly GetNichesRequestMarket Be = new(Values.Be);

    public static readonly GetNichesRequestMarket All = new(Values.All);

    public GetNichesRequestMarket(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static GetNichesRequestMarket FromCustom(string value)
    {
        return new GetNichesRequestMarket(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(GetNichesRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetNichesRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetNichesRequestMarket value) => value.Value;

    public static explicit operator GetNichesRequestMarket(string value) => new(value);

    internal class GetNichesRequestMarketSerializer : JsonConverter<GetNichesRequestMarket>
    {
        public override GetNichesRequestMarket Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new GetNichesRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetNichesRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetNichesRequestMarket ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new GetNichesRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetNichesRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Nl = "NL";

        public const string Be = "BE";

        public const string All = "ALL";
    }
}
