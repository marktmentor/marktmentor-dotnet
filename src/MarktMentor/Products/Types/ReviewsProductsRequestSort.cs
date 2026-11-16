using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsProductsRequestSort.ReviewsProductsRequestSortSerializer))]
[Serializable]
public readonly record struct ReviewsProductsRequestSort : IStringEnum
{
    public static readonly ReviewsProductsRequestSort DateAsc = new(Values.DateAsc);

    public static readonly ReviewsProductsRequestSort DateDesc = new(Values.DateDesc);

    public static readonly ReviewsProductsRequestSort ScoreAsc = new(Values.ScoreAsc);

    public static readonly ReviewsProductsRequestSort ScoreDesc = new(Values.ScoreDesc);

    public ReviewsProductsRequestSort(string value)
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
    public static ReviewsProductsRequestSort FromCustom(string value)
    {
        return new ReviewsProductsRequestSort(value);
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

    public static bool operator ==(ReviewsProductsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsProductsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsProductsRequestSort value) => value.Value;

    public static explicit operator ReviewsProductsRequestSort(string value) => new(value);

    internal class ReviewsProductsRequestSortSerializer : JsonConverter<ReviewsProductsRequestSort>
    {
        public override ReviewsProductsRequestSort Read(
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
            return new ReviewsProductsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsProductsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsProductsRequestSort ReadAsPropertyName(
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
            return new ReviewsProductsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsProductsRequestSort value,
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
        public const string DateAsc = "date";

        public const string DateDesc = "-date";

        public const string ScoreAsc = "score";

        public const string ScoreDesc = "-score";
    }
}
