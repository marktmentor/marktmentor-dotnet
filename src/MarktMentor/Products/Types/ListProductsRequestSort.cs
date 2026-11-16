using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ListProductsRequestSort.ListProductsRequestSortSerializer))]
[Serializable]
public readonly record struct ListProductsRequestSort : IStringEnum
{
    public static readonly ListProductsRequestSort SalesAsc = new(Values.SalesAsc);

    public static readonly ListProductsRequestSort SalesDesc = new(Values.SalesDesc);

    public static readonly ListProductsRequestSort RevenueAsc = new(Values.RevenueAsc);

    public static readonly ListProductsRequestSort RevenueDesc = new(Values.RevenueDesc);

    public static readonly ListProductsRequestSort PriceAsc = new(Values.PriceAsc);

    public static readonly ListProductsRequestSort PriceDesc = new(Values.PriceDesc);

    public ListProductsRequestSort(string value)
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
    public static ListProductsRequestSort FromCustom(string value)
    {
        return new ListProductsRequestSort(value);
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

    public static bool operator ==(ListProductsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListProductsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListProductsRequestSort value) => value.Value;

    public static explicit operator ListProductsRequestSort(string value) => new(value);

    internal class ListProductsRequestSortSerializer : JsonConverter<ListProductsRequestSort>
    {
        public override ListProductsRequestSort Read(
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
            return new ListProductsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListProductsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListProductsRequestSort ReadAsPropertyName(
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
            return new ListProductsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListProductsRequestSort value,
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
        public const string SalesAsc = "sales";

        public const string SalesDesc = "-sales";

        public const string RevenueAsc = "revenue";

        public const string RevenueDesc = "-revenue";

        public const string PriceAsc = "price";

        public const string PriceDesc = "-price";
    }
}
