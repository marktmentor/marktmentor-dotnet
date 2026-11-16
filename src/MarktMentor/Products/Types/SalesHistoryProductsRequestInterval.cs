using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(SalesHistoryProductsRequestInterval.SalesHistoryProductsRequestIntervalSerializer)
)]
[Serializable]
public readonly record struct SalesHistoryProductsRequestInterval : IStringEnum
{
    public static readonly SalesHistoryProductsRequestInterval Week = new(Values.Week);

    public static readonly SalesHistoryProductsRequestInterval Month = new(Values.Month);

    public SalesHistoryProductsRequestInterval(string value)
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
    public static SalesHistoryProductsRequestInterval FromCustom(string value)
    {
        return new SalesHistoryProductsRequestInterval(value);
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

    public static bool operator ==(SalesHistoryProductsRequestInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SalesHistoryProductsRequestInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SalesHistoryProductsRequestInterval value) =>
        value.Value;

    public static explicit operator SalesHistoryProductsRequestInterval(string value) => new(value);

    internal class SalesHistoryProductsRequestIntervalSerializer
        : JsonConverter<SalesHistoryProductsRequestInterval>
    {
        public override SalesHistoryProductsRequestInterval Read(
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
            return new SalesHistoryProductsRequestInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SalesHistoryProductsRequestInterval ReadAsPropertyName(
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
            return new SalesHistoryProductsRequestInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestInterval value,
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
