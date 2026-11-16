using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(KeywordRankingsProductsRequestMarket.KeywordRankingsProductsRequestMarketSerializer)
)]
[Serializable]
public readonly record struct KeywordRankingsProductsRequestMarket : IStringEnum
{
    public static readonly KeywordRankingsProductsRequestMarket Nl = new(Values.Nl);

    public static readonly KeywordRankingsProductsRequestMarket Be = new(Values.Be);

    public static readonly KeywordRankingsProductsRequestMarket All = new(Values.All);

    public KeywordRankingsProductsRequestMarket(string value)
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
    public static KeywordRankingsProductsRequestMarket FromCustom(string value)
    {
        return new KeywordRankingsProductsRequestMarket(value);
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

    public static bool operator ==(KeywordRankingsProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KeywordRankingsProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KeywordRankingsProductsRequestMarket value) =>
        value.Value;

    public static explicit operator KeywordRankingsProductsRequestMarket(string value) =>
        new(value);

    internal class KeywordRankingsProductsRequestMarketSerializer
        : JsonConverter<KeywordRankingsProductsRequestMarket>
    {
        public override KeywordRankingsProductsRequestMarket Read(
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
            return new KeywordRankingsProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KeywordRankingsProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KeywordRankingsProductsRequestMarket ReadAsPropertyName(
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
            return new KeywordRankingsProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KeywordRankingsProductsRequestMarket value,
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
