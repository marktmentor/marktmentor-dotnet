using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductsNichesRequestSort.ProductsNichesRequestSortSerializer))]
[Serializable]
public readonly record struct ProductsNichesRequestSort : IStringEnum
{
    public static readonly ProductsNichesRequestSort SalesAsc = new(Values.SalesAsc);

    public static readonly ProductsNichesRequestSort SalesDesc = new(Values.SalesDesc);

    public static readonly ProductsNichesRequestSort RevenueAsc = new(Values.RevenueAsc);

    public static readonly ProductsNichesRequestSort RevenueDesc = new(Values.RevenueDesc);

    public static readonly ProductsNichesRequestSort PriceAsc = new(Values.PriceAsc);

    public static readonly ProductsNichesRequestSort PriceDesc = new(Values.PriceDesc);

    public ProductsNichesRequestSort(string value)
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
    public static ProductsNichesRequestSort FromCustom(string value)
    {
        return new ProductsNichesRequestSort(value);
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

    public static bool operator ==(ProductsNichesRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductsNichesRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductsNichesRequestSort value) => value.Value;

    public static explicit operator ProductsNichesRequestSort(string value) => new(value);

    internal class ProductsNichesRequestSortSerializer : JsonConverter<ProductsNichesRequestSort>
    {
        public override ProductsNichesRequestSort Read(
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
            return new ProductsNichesRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductsNichesRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductsNichesRequestSort ReadAsPropertyName(
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
            return new ProductsNichesRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductsNichesRequestSort value,
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
