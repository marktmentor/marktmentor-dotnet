using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(SellersProductsRequestPeriod.SellersProductsRequestPeriodSerializer))]
[Serializable]
public readonly record struct SellersProductsRequestPeriod : IStringEnum
{
    public static readonly SellersProductsRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly SellersProductsRequestPeriod OneHundredEightyD = new(
        Values.OneHundredEightyD
    );

    public static readonly SellersProductsRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public static readonly SellersProductsRequestPeriod SevenHundredThirtyD = new(
        Values.SevenHundredThirtyD
    );

    public SellersProductsRequestPeriod(string value)
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
    public static SellersProductsRequestPeriod FromCustom(string value)
    {
        return new SellersProductsRequestPeriod(value);
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

    public static bool operator ==(SellersProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SellersProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SellersProductsRequestPeriod value) => value.Value;

    public static explicit operator SellersProductsRequestPeriod(string value) => new(value);

    internal class SellersProductsRequestPeriodSerializer
        : JsonConverter<SellersProductsRequestPeriod>
    {
        public override SellersProductsRequestPeriod Read(
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
            return new SellersProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SellersProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SellersProductsRequestPeriod ReadAsPropertyName(
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
            return new SellersProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SellersProductsRequestPeriod value,
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
        public const string NinetyD = "90d";

        public const string OneHundredEightyD = "180d";

        public const string ThreeHundredSixtyFiveD = "365d";

        public const string SevenHundredThirtyD = "730d";
    }
}
