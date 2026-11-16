using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(VisibilityHistoryProductsRequestPeriod.VisibilityHistoryProductsRequestPeriodSerializer)
)]
[Serializable]
public readonly record struct VisibilityHistoryProductsRequestPeriod : IStringEnum
{
    public static readonly VisibilityHistoryProductsRequestPeriod ThreeM = new(Values.ThreeM);

    public static readonly VisibilityHistoryProductsRequestPeriod SixM = new(Values.SixM);

    public static readonly VisibilityHistoryProductsRequestPeriod OneY = new(Values.OneY);

    public static readonly VisibilityHistoryProductsRequestPeriod TwoY = new(Values.TwoY);

    public VisibilityHistoryProductsRequestPeriod(string value)
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
    public static VisibilityHistoryProductsRequestPeriod FromCustom(string value)
    {
        return new VisibilityHistoryProductsRequestPeriod(value);
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

    public static bool operator ==(VisibilityHistoryProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VisibilityHistoryProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VisibilityHistoryProductsRequestPeriod value) =>
        value.Value;

    public static explicit operator VisibilityHistoryProductsRequestPeriod(string value) =>
        new(value);

    internal class VisibilityHistoryProductsRequestPeriodSerializer
        : JsonConverter<VisibilityHistoryProductsRequestPeriod>
    {
        public override VisibilityHistoryProductsRequestPeriod Read(
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
            return new VisibilityHistoryProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VisibilityHistoryProductsRequestPeriod ReadAsPropertyName(
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
            return new VisibilityHistoryProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestPeriod value,
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
