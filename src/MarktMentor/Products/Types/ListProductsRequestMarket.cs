using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ListProductsRequestMarket.ListProductsRequestMarketSerializer))]
[Serializable]
public readonly record struct ListProductsRequestMarket : IStringEnum
{
    public static readonly ListProductsRequestMarket Nl = new(Values.Nl);

    public static readonly ListProductsRequestMarket Be = new(Values.Be);

    public static readonly ListProductsRequestMarket All = new(Values.All);

    public ListProductsRequestMarket(string value)
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
    public static ListProductsRequestMarket FromCustom(string value)
    {
        return new ListProductsRequestMarket(value);
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

    public static bool operator ==(ListProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListProductsRequestMarket value) => value.Value;

    public static explicit operator ListProductsRequestMarket(string value) => new(value);

    internal class ListProductsRequestMarketSerializer : JsonConverter<ListProductsRequestMarket>
    {
        public override ListProductsRequestMarket Read(
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
            return new ListProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListProductsRequestMarket ReadAsPropertyName(
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
            return new ListProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListProductsRequestMarket value,
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
