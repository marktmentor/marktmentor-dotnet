using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(SalesHistoryProductsRequestPeriod.SalesHistoryProductsRequestPeriodSerializer)
)]
[Serializable]
public readonly record struct SalesHistoryProductsRequestPeriod : IStringEnum
{
    public static readonly SalesHistoryProductsRequestPeriod ThreeM = new(Values.ThreeM);

    public static readonly SalesHistoryProductsRequestPeriod SixM = new(Values.SixM);

    public static readonly SalesHistoryProductsRequestPeriod OneY = new(Values.OneY);

    public static readonly SalesHistoryProductsRequestPeriod TwoY = new(Values.TwoY);

    public SalesHistoryProductsRequestPeriod(string value)
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
    public static SalesHistoryProductsRequestPeriod FromCustom(string value)
    {
        return new SalesHistoryProductsRequestPeriod(value);
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

    public static bool operator ==(SalesHistoryProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SalesHistoryProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SalesHistoryProductsRequestPeriod value) => value.Value;

    public static explicit operator SalesHistoryProductsRequestPeriod(string value) => new(value);

    internal class SalesHistoryProductsRequestPeriodSerializer
        : JsonConverter<SalesHistoryProductsRequestPeriod>
    {
        public override SalesHistoryProductsRequestPeriod Read(
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
            return new SalesHistoryProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SalesHistoryProductsRequestPeriod ReadAsPropertyName(
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
            return new SalesHistoryProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestPeriod value,
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
        public const string ThreeM = "3M";

        public const string SixM = "6M";

        public const string OneY = "1Y";

        public const string TwoY = "2Y";
    }
}
