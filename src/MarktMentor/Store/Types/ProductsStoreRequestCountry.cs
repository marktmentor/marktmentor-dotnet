using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductsStoreRequestCountry.ProductsStoreRequestCountrySerializer))]
[Serializable]
public readonly record struct ProductsStoreRequestCountry : IStringEnum
{
    public static readonly ProductsStoreRequestCountry Nl = new(Values.Nl);

    public static readonly ProductsStoreRequestCountry Be = new(Values.Be);

    public ProductsStoreRequestCountry(string value)
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
    public static ProductsStoreRequestCountry FromCustom(string value)
    {
        return new ProductsStoreRequestCountry(value);
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

    public static bool operator ==(ProductsStoreRequestCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductsStoreRequestCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductsStoreRequestCountry value) => value.Value;

    public static explicit operator ProductsStoreRequestCountry(string value) => new(value);

    internal class ProductsStoreRequestCountrySerializer
        : JsonConverter<ProductsStoreRequestCountry>
    {
        public override ProductsStoreRequestCountry Read(
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
            return new ProductsStoreRequestCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductsStoreRequestCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductsStoreRequestCountry ReadAsPropertyName(
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
            return new ProductsStoreRequestCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductsStoreRequestCountry value,
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
    }
}
