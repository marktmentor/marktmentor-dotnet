using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductsStoreRequestSort.ProductsStoreRequestSortSerializer))]
[Serializable]
public readonly record struct ProductsStoreRequestSort : IStringEnum
{
    public static readonly ProductsStoreRequestSort RevenueAsc = new(Values.RevenueAsc);

    public static readonly ProductsStoreRequestSort RevenueDesc = new(Values.RevenueDesc);

    public static readonly ProductsStoreRequestSort SalesAsc = new(Values.SalesAsc);

    public static readonly ProductsStoreRequestSort SalesDesc = new(Values.SalesDesc);

    public static readonly ProductsStoreRequestSort CostsAsc = new(Values.CostsAsc);

    public static readonly ProductsStoreRequestSort CostsDesc = new(Values.CostsDesc);

    public static readonly ProductsStoreRequestSort ProfitsAsc = new(Values.ProfitsAsc);

    public static readonly ProductsStoreRequestSort ProfitsDesc = new(Values.ProfitsDesc);

    public ProductsStoreRequestSort(string value)
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
    public static ProductsStoreRequestSort FromCustom(string value)
    {
        return new ProductsStoreRequestSort(value);
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

    public static bool operator ==(ProductsStoreRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductsStoreRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductsStoreRequestSort value) => value.Value;

    public static explicit operator ProductsStoreRequestSort(string value) => new(value);

    internal class ProductsStoreRequestSortSerializer : JsonConverter<ProductsStoreRequestSort>
    {
        public override ProductsStoreRequestSort Read(
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
            return new ProductsStoreRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductsStoreRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductsStoreRequestSort ReadAsPropertyName(
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
            return new ProductsStoreRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductsStoreRequestSort value,
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

        public const string SalesAsc = "sales";

        public const string SalesDesc = "-sales";

        public const string CostsAsc = "costs";

        public const string CostsDesc = "-costs";

        public const string ProfitsAsc = "profits";

        public const string ProfitsDesc = "-profits";
    }
}
