using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsProductsRequestMarket.ReviewsProductsRequestMarketSerializer))]
[Serializable]
public readonly record struct ReviewsProductsRequestMarket : IStringEnum
{
    public static readonly ReviewsProductsRequestMarket All = new(Values.All);

    public ReviewsProductsRequestMarket(string value)
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
    public static ReviewsProductsRequestMarket FromCustom(string value)
    {
        return new ReviewsProductsRequestMarket(value);
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

    public static bool operator ==(ReviewsProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsProductsRequestMarket value) => value.Value;

    public static explicit operator ReviewsProductsRequestMarket(string value) => new(value);

    internal class ReviewsProductsRequestMarketSerializer
        : JsonConverter<ReviewsProductsRequestMarket>
    {
        public override ReviewsProductsRequestMarket Read(
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
            return new ReviewsProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsProductsRequestMarket ReadAsPropertyName(
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
            return new ReviewsProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsProductsRequestMarket value,
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
