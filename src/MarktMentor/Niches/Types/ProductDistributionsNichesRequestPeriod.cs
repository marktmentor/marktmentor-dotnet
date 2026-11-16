using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(ProductDistributionsNichesRequestPeriod.ProductDistributionsNichesRequestPeriodSerializer)
)]
[Serializable]
public readonly record struct ProductDistributionsNichesRequestPeriod : IStringEnum
{
    public static readonly ProductDistributionsNichesRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly ProductDistributionsNichesRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly ProductDistributionsNichesRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public ProductDistributionsNichesRequestPeriod(string value)
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
    public static ProductDistributionsNichesRequestPeriod FromCustom(string value)
    {
        return new ProductDistributionsNichesRequestPeriod(value);
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

    public static bool operator ==(ProductDistributionsNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ProductDistributionsNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ProductDistributionsNichesRequestPeriod value) =>
        value.Value;

    public static explicit operator ProductDistributionsNichesRequestPeriod(string value) =>
        new(value);

    internal class ProductDistributionsNichesRequestPeriodSerializer
        : JsonConverter<ProductDistributionsNichesRequestPeriod>
    {
        public override ProductDistributionsNichesRequestPeriod Read(
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
            return new ProductDistributionsNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProductDistributionsNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ProductDistributionsNichesRequestPeriod ReadAsPropertyName(
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
            return new ProductDistributionsNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ProductDistributionsNichesRequestPeriod value,
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
