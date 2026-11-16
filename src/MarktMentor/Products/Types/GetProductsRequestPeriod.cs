using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(GetProductsRequestPeriod.GetProductsRequestPeriodSerializer))]
[Serializable]
public readonly record struct GetProductsRequestPeriod : IStringEnum
{
    public static readonly GetProductsRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly GetProductsRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly GetProductsRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public GetProductsRequestPeriod(string value)
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
    public static GetProductsRequestPeriod FromCustom(string value)
    {
        return new GetProductsRequestPeriod(value);
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

    public static bool operator ==(GetProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetProductsRequestPeriod value) => value.Value;

    public static explicit operator GetProductsRequestPeriod(string value) => new(value);

    internal class GetProductsRequestPeriodSerializer : JsonConverter<GetProductsRequestPeriod>
    {
        public override GetProductsRequestPeriod Read(
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
            return new GetProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetProductsRequestPeriod ReadAsPropertyName(
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
            return new GetProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetProductsRequestPeriod value,
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
