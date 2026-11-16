using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(VisibilityHistoryProductsRequestInterval.VisibilityHistoryProductsRequestIntervalSerializer)
)]
[Serializable]
public readonly record struct VisibilityHistoryProductsRequestInterval : IStringEnum
{
    public static readonly VisibilityHistoryProductsRequestInterval Week = new(Values.Week);

    public static readonly VisibilityHistoryProductsRequestInterval Month = new(Values.Month);

    public VisibilityHistoryProductsRequestInterval(string value)
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
    public static VisibilityHistoryProductsRequestInterval FromCustom(string value)
    {
        return new VisibilityHistoryProductsRequestInterval(value);
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

    public static bool operator ==(
        VisibilityHistoryProductsRequestInterval value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        VisibilityHistoryProductsRequestInterval value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(VisibilityHistoryProductsRequestInterval value) =>
        value.Value;

    public static explicit operator VisibilityHistoryProductsRequestInterval(string value) =>
        new(value);

    internal class VisibilityHistoryProductsRequestIntervalSerializer
        : JsonConverter<VisibilityHistoryProductsRequestInterval>
    {
        public override VisibilityHistoryProductsRequestInterval Read(
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
            return new VisibilityHistoryProductsRequestInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VisibilityHistoryProductsRequestInterval ReadAsPropertyName(
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
            return new VisibilityHistoryProductsRequestInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestInterval value,
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
