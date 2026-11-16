using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsNichesRequestMarket.ReviewsNichesRequestMarketSerializer))]
[Serializable]
public readonly record struct ReviewsNichesRequestMarket : IStringEnum
{
    public static readonly ReviewsNichesRequestMarket All = new(Values.All);

    public ReviewsNichesRequestMarket(string value)
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
    public static ReviewsNichesRequestMarket FromCustom(string value)
    {
        return new ReviewsNichesRequestMarket(value);
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

    public static bool operator ==(ReviewsNichesRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsNichesRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsNichesRequestMarket value) => value.Value;

    public static explicit operator ReviewsNichesRequestMarket(string value) => new(value);

    internal class ReviewsNichesRequestMarketSerializer : JsonConverter<ReviewsNichesRequestMarket>
    {
        public override ReviewsNichesRequestMarket Read(
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
            return new ReviewsNichesRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsNichesRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsNichesRequestMarket ReadAsPropertyName(
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
            return new ReviewsNichesRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsNichesRequestMarket value,
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
        public const string All = "ALL";
    }
}
