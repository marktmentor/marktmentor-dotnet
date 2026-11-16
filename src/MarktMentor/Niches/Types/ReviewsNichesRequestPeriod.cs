using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsNichesRequestPeriod.ReviewsNichesRequestPeriodSerializer))]
[Serializable]
public readonly record struct ReviewsNichesRequestPeriod : IStringEnum
{
    public static readonly ReviewsNichesRequestPeriod ThreeM = new(Values.ThreeM);

    public static readonly ReviewsNichesRequestPeriod SixM = new(Values.SixM);

    public static readonly ReviewsNichesRequestPeriod OneY = new(Values.OneY);

    public static readonly ReviewsNichesRequestPeriod TwoY = new(Values.TwoY);

    public ReviewsNichesRequestPeriod(string value)
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
    public static ReviewsNichesRequestPeriod FromCustom(string value)
    {
        return new ReviewsNichesRequestPeriod(value);
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

    public static bool operator ==(ReviewsNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsNichesRequestPeriod value) => value.Value;

    public static explicit operator ReviewsNichesRequestPeriod(string value) => new(value);

    internal class ReviewsNichesRequestPeriodSerializer : JsonConverter<ReviewsNichesRequestPeriod>
    {
        public override ReviewsNichesRequestPeriod Read(
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
            return new ReviewsNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsNichesRequestPeriod ReadAsPropertyName(
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
            return new ReviewsNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsNichesRequestPeriod value,
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
