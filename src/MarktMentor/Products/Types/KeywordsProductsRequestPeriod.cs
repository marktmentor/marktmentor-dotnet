using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(KeywordsProductsRequestPeriod.KeywordsProductsRequestPeriodSerializer))]
[Serializable]
public readonly record struct KeywordsProductsRequestPeriod : IStringEnum
{
    public static readonly KeywordsProductsRequestPeriod SevenD = new(Values.SevenD);

    public static readonly KeywordsProductsRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly KeywordsProductsRequestPeriod NinetyD = new(Values.NinetyD);

    public KeywordsProductsRequestPeriod(string value)
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
    public static KeywordsProductsRequestPeriod FromCustom(string value)
    {
        return new KeywordsProductsRequestPeriod(value);
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

    public static bool operator ==(KeywordsProductsRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KeywordsProductsRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KeywordsProductsRequestPeriod value) => value.Value;

    public static explicit operator KeywordsProductsRequestPeriod(string value) => new(value);

    internal class KeywordsProductsRequestPeriodSerializer
        : JsonConverter<KeywordsProductsRequestPeriod>
    {
        public override KeywordsProductsRequestPeriod Read(
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
            return new KeywordsProductsRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KeywordsProductsRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KeywordsProductsRequestPeriod ReadAsPropertyName(
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
            return new KeywordsProductsRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KeywordsProductsRequestPeriod value,
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
        public const string SevenD = "7d";

        public const string ThirtyD = "30d";

        public const string NinetyD = "90d";
    }
}
