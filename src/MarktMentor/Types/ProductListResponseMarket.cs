using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductListResponseMarket.ProductListResponseMarketSerializer))]
[Serializable]
public readonly record struct ProductListResponseMarket : IStringEnum
{
    public static readonly ProductListResponseMarket Nl = new(Values.Nl);

    public static readonly ProductListResponseMarket Be = new(Values.Be);

    public static readonly ProductListResponseMarket All = new(Values.All);

    public ProductListResponseMarket(string value)
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
    public static ProductListResponseMarket FromCustom(string value)
    {
        return new ProductListResponseMarket(value);
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

    public static bool operator ==(ProductListResponseMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductListResponseMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductListResponseMarket value) => value.Value;

    public static explicit operator ProductListResponseMarket(string value) => new(value);

    internal class ProductListResponseMarketSerializer : JsonConverter<ProductListResponseMarket>
    {
        public override ProductListResponseMarket Read(
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
            return new ProductListResponseMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductListResponseMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductListResponseMarket ReadAsPropertyName(
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
            return new ProductListResponseMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductListResponseMarket value,
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
