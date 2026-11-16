using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(KeywordsProductsRequestMarket.KeywordsProductsRequestMarketSerializer))]
[Serializable]
public readonly record struct KeywordsProductsRequestMarket : IStringEnum
{
    public static readonly KeywordsProductsRequestMarket Nl = new(Values.Nl);

    public static readonly KeywordsProductsRequestMarket Be = new(Values.Be);

    public static readonly KeywordsProductsRequestMarket All = new(Values.All);

    public KeywordsProductsRequestMarket(string value)
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
    public static KeywordsProductsRequestMarket FromCustom(string value)
    {
        return new KeywordsProductsRequestMarket(value);
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

    public static bool operator ==(KeywordsProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KeywordsProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KeywordsProductsRequestMarket value) => value.Value;

    public static explicit operator KeywordsProductsRequestMarket(string value) => new(value);

    internal class KeywordsProductsRequestMarketSerializer
        : JsonConverter<KeywordsProductsRequestMarket>
    {
        public override KeywordsProductsRequestMarket Read(
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
            return new KeywordsProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KeywordsProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KeywordsProductsRequestMarket ReadAsPropertyName(
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
            return new KeywordsProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KeywordsProductsRequestMarket value,
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
