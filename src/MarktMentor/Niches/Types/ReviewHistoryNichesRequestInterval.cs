using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(ReviewHistoryNichesRequestInterval.ReviewHistoryNichesRequestIntervalSerializer)
)]
[Serializable]
public readonly record struct ReviewHistoryNichesRequestInterval : IStringEnum
{
    public static readonly ReviewHistoryNichesRequestInterval Week = new(Values.Week);

    public static readonly ReviewHistoryNichesRequestInterval Month = new(Values.Month);

    public ReviewHistoryNichesRequestInterval(string value)
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
    public static ReviewHistoryNichesRequestInterval FromCustom(string value)
    {
        return new ReviewHistoryNichesRequestInterval(value);
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

    public static bool operator ==(ReviewHistoryNichesRequestInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewHistoryNichesRequestInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewHistoryNichesRequestInterval value) => value.Value;

    public static explicit operator ReviewHistoryNichesRequestInterval(string value) => new(value);

    internal class ReviewHistoryNichesRequestIntervalSerializer
        : JsonConverter<ReviewHistoryNichesRequestInterval>
    {
        public override ReviewHistoryNichesRequestInterval Read(
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
            return new ReviewHistoryNichesRequestInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewHistoryNichesRequestInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewHistoryNichesRequestInterval ReadAsPropertyName(
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
            return new ReviewHistoryNichesRequestInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewHistoryNichesRequestInterval value,
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
