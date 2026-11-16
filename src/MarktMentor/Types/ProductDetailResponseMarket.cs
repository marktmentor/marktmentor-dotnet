using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductDetailResponseMarket.ProductDetailResponseMarketSerializer))]
[Serializable]
public readonly record struct ProductDetailResponseMarket : IStringEnum
{
    public static readonly ProductDetailResponseMarket Nl = new(Values.Nl);

    public static readonly ProductDetailResponseMarket Be = new(Values.Be);

    public static readonly ProductDetailResponseMarket All = new(Values.All);

    public ProductDetailResponseMarket(string value)
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
    public static ProductDetailResponseMarket FromCustom(string value)
    {
        return new ProductDetailResponseMarket(value);
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

    public static bool operator ==(ProductDetailResponseMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductDetailResponseMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductDetailResponseMarket value) => value.Value;

    public static explicit operator ProductDetailResponseMarket(string value) => new(value);

    internal class ProductDetailResponseMarketSerializer
        : JsonConverter<ProductDetailResponseMarket>
    {
        public override ProductDetailResponseMarket Read(
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
            return new ProductDetailResponseMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductDetailResponseMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductDetailResponseMarket ReadAsPropertyName(
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
            return new ProductDetailResponseMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductDetailResponseMarket value,
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
