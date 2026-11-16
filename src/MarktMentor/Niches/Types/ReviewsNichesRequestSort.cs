using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ReviewsNichesRequestSort.ReviewsNichesRequestSortSerializer))]
[Serializable]
public readonly record struct ReviewsNichesRequestSort : IStringEnum
{
    public static readonly ReviewsNichesRequestSort DateAsc = new(Values.DateAsc);

    public static readonly ReviewsNichesRequestSort DateDesc = new(Values.DateDesc);

    public static readonly ReviewsNichesRequestSort ScoreAsc = new(Values.ScoreAsc);

    public static readonly ReviewsNichesRequestSort ScoreDesc = new(Values.ScoreDesc);

    public ReviewsNichesRequestSort(string value)
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
    public static ReviewsNichesRequestSort FromCustom(string value)
    {
        return new ReviewsNichesRequestSort(value);
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

    public static bool operator ==(ReviewsNichesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ReviewsNichesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ReviewsNichesRequestSort value) => value.Value;

    public static explicit operator ReviewsNichesRequestSort(string value) => new(value);

    internal class ReviewsNichesRequestSortSerializer : JsonConverter<ReviewsNichesRequestSort>
    {
        public override ReviewsNichesRequestSort Read(
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
            return new ReviewsNichesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReviewsNichesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ReviewsNichesRequestSort ReadAsPropertyName(
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
            return new ReviewsNichesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ReviewsNichesRequestSort value,
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
