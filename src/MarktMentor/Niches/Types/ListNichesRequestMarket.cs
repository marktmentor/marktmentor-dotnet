using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ListNichesRequestMarket.ListNichesRequestMarketSerializer))]
[Serializable]
public readonly record struct ListNichesRequestMarket : IStringEnum
{
    public static readonly ListNichesRequestMarket Nl = new(Values.Nl);

    public static readonly ListNichesRequestMarket Be = new(Values.Be);

    public static readonly ListNichesRequestMarket All = new(Values.All);

    public ListNichesRequestMarket(string value)
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
    public static ListNichesRequestMarket FromCustom(string value)
    {
        return new ListNichesRequestMarket(value);
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

    public static bool operator ==(ListNichesRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListNichesRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListNichesRequestMarket value) => value.Value;

    public static explicit operator ListNichesRequestMarket(string value) => new(value);

    internal class ListNichesRequestMarketSerializer : JsonConverter<ListNichesRequestMarket>
    {
        public override ListNichesRequestMarket Read(
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
            return new ListNichesRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListNichesRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListNichesRequestMarket ReadAsPropertyName(
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
            return new ListNichesRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListNichesRequestMarket value,
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
