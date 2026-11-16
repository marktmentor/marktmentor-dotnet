using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductsNichesRequestMarket.ProductsNichesRequestMarketSerializer))]
[Serializable]
public readonly record struct ProductsNichesRequestMarket : IStringEnum
{
    public static readonly ProductsNichesRequestMarket Nl = new(Values.Nl);

    public static readonly ProductsNichesRequestMarket Be = new(Values.Be);

    public static readonly ProductsNichesRequestMarket All = new(Values.All);

    public ProductsNichesRequestMarket(string value)
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
    public static ProductsNichesRequestMarket FromCustom(string value)
    {
        return new ProductsNichesRequestMarket(value);
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

    public static bool operator ==(ProductsNichesRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductsNichesRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductsNichesRequestMarket value) => value.Value;

    public static explicit operator ProductsNichesRequestMarket(string value) => new(value);

    internal class ProductsNichesRequestMarketSerializer
        : JsonConverter<ProductsNichesRequestMarket>
    {
        public override ProductsNichesRequestMarket Read(
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
            return new ProductsNichesRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductsNichesRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductsNichesRequestMarket ReadAsPropertyName(
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
            return new ProductsNichesRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductsNichesRequestMarket value,
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
        public const string Nl = "NL";

        public const string Be = "BE";

        public const string All = "ALL";
    }
}
