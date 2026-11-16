using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ProductsNichesRequestPeriod.ProductsNichesRequestPeriodSerializer))]
[Serializable]
public readonly record struct ProductsNichesRequestPeriod : IStringEnum
{
    public static readonly ProductsNichesRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly ProductsNichesRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly ProductsNichesRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public ProductsNichesRequestPeriod(string value)
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
    public static ProductsNichesRequestPeriod FromCustom(string value)
    {
        return new ProductsNichesRequestPeriod(value);
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

    public static bool operator ==(ProductsNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductsNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductsNichesRequestPeriod value) => value.Value;

    public static explicit operator ProductsNichesRequestPeriod(string value) => new(value);

    internal class ProductsNichesRequestPeriodSerializer
        : JsonConverter<ProductsNichesRequestPeriod>
    {
        public override ProductsNichesRequestPeriod Read(
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
            return new ProductsNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductsNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductsNichesRequestPeriod ReadAsPropertyName(
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
            return new ProductsNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductsNichesRequestPeriod value,
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
        public const string ThirtyD = "30d";

        public const string NinetyD = "90d";

        public const string ThreeHundredSixtyFiveD = "365d";
    }
}
