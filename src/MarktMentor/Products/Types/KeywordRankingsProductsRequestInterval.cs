using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(KeywordRankingsProductsRequestInterval.KeywordRankingsProductsRequestIntervalSerializer)
)]
[Serializable]
public readonly record struct KeywordRankingsProductsRequestInterval : IStringEnum
{
    public static readonly KeywordRankingsProductsRequestInterval Week = new(Values.Week);

    public static readonly KeywordRankingsProductsRequestInterval Month = new(Values.Month);

    public KeywordRankingsProductsRequestInterval(string value)
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
    public static KeywordRankingsProductsRequestInterval FromCustom(string value)
    {
        return new KeywordRankingsProductsRequestInterval(value);
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

    public static bool operator ==(KeywordRankingsProductsRequestInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KeywordRankingsProductsRequestInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KeywordRankingsProductsRequestInterval value) =>
        value.Value;

    public static explicit operator KeywordRankingsProductsRequestInterval(string value) =>
        new(value);

    internal class KeywordRankingsProductsRequestIntervalSerializer
        : JsonConverter<KeywordRankingsProductsRequestInterval>
    {
        public override KeywordRankingsProductsRequestInterval Read(
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
            return new KeywordRankingsProductsRequestInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KeywordRankingsProductsRequestInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KeywordRankingsProductsRequestInterval ReadAsPropertyName(
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
            return new KeywordRankingsProductsRequestInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KeywordRankingsProductsRequestInterval value,
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
        public const string Week = "week";

        public const string Month = "month";
    }
}
