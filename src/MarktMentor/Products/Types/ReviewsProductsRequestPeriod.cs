using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsProductsRequestPeriod.ReviewsProductsRequestPeriodSerializer))]
[Serializable]
public readonly record struct ReviewsProductsRequestPeriod : IStringEnum
{
    public static readonly ReviewsProductsRequestPeriod ThreeM = new(Values.ThreeM);

    public static readonly ReviewsProductsRequestPeriod SixM = new(Values.SixM);

    public static readonly ReviewsProductsRequestPeriod OneY = new(Values.OneY);

    public static readonly ReviewsProductsRequestPeriod TwoY = new(Values.TwoY);

    public ReviewsProductsRequestPeriod(string value)
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
    public static ReviewsProductsRequestPeriod FromCustom(string value)
    {
        return new ReviewsProductsRequestPeriod(value);
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

    public static bool operator ==(ReviewsProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsProductsRequestPeriod value) => value.Value;

    public static explicit operator ReviewsProductsRequestPeriod(string value) => new(value);

    internal class ReviewsProductsRequestPeriodSerializer
        : JsonConverter<ReviewsProductsRequestPeriod>
    {
        public override ReviewsProductsRequestPeriod Read(
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
            return new ReviewsProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsProductsRequestPeriod ReadAsPropertyName(
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
            return new ReviewsProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsProductsRequestPeriod value,
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
