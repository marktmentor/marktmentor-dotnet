using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewHistoryNichesRequestPeriod.ReviewHistoryNichesRequestPeriodSerializer))]
[Serializable]
public readonly record struct ReviewHistoryNichesRequestPeriod : IStringEnum
{
    public static readonly ReviewHistoryNichesRequestPeriod ThreeM = new(Values.ThreeM);

    public static readonly ReviewHistoryNichesRequestPeriod SixM = new(Values.SixM);

    public static readonly ReviewHistoryNichesRequestPeriod OneY = new(Values.OneY);

    public static readonly ReviewHistoryNichesRequestPeriod TwoY = new(Values.TwoY);

    public ReviewHistoryNichesRequestPeriod(string value)
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
    public static ReviewHistoryNichesRequestPeriod FromCustom(string value)
    {
        return new ReviewHistoryNichesRequestPeriod(value);
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

    public static bool operator ==(ReviewHistoryNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewHistoryNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewHistoryNichesRequestPeriod value) => value.Value;

    public static explicit operator ReviewHistoryNichesRequestPeriod(string value) => new(value);

    internal class ReviewHistoryNichesRequestPeriodSerializer
        : JsonConverter<ReviewHistoryNichesRequestPeriod>
    {
        public override ReviewHistoryNichesRequestPeriod Read(
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
            return new ReviewHistoryNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewHistoryNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewHistoryNichesRequestPeriod ReadAsPropertyName(
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
            return new ReviewHistoryNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewHistoryNichesRequestPeriod value,
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
        public const string ThreeM = "3M";

        public const string SixM = "6M";

        public const string OneY = "1Y";

        public const string TwoY = "2Y";
    }
}
