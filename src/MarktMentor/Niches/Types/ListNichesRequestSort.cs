using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ListNichesRequestSort.ListNichesRequestSortSerializer))]
[Serializable]
public readonly record struct ListNichesRequestSort : IStringEnum
{
    public static readonly ListNichesRequestSort RevenueAsc = new(Values.RevenueAsc);

    public static readonly ListNichesRequestSort RevenueDesc = new(Values.RevenueDesc);

    public static readonly ListNichesRequestSort VolumeAsc = new(Values.VolumeAsc);

    public static readonly ListNichesRequestSort VolumeDesc = new(Values.VolumeDesc);

    public static readonly ListNichesRequestSort ProductsAsc = new(Values.ProductsAsc);

    public static readonly ListNichesRequestSort ProductsDesc = new(Values.ProductsDesc);

    public ListNichesRequestSort(string value)
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
    public static ListNichesRequestSort FromCustom(string value)
    {
        return new ListNichesRequestSort(value);
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

    public static bool operator ==(ListNichesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListNichesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListNichesRequestSort value) => value.Value;

    public static explicit operator ListNichesRequestSort(string value) => new(value);

    internal class ListNichesRequestSortSerializer : JsonConverter<ListNichesRequestSort>
    {
        public override ListNichesRequestSort Read(
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
            return new ListNichesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListNichesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListNichesRequestSort ReadAsPropertyName(
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
            return new ListNichesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListNichesRequestSort value,
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
        public const string RevenueAsc = "revenue";

        public const string RevenueDesc = "-revenue";

        public const string VolumeAsc = "volume";

        public const string VolumeDesc = "-volume";

        public const string ProductsAsc = "products";

        public const string ProductsDesc = "-products";
    }
}
