using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(ListNichesRequestPeriod.ListNichesRequestPeriodSerializer))]
[Serializable]
public readonly record struct ListNichesRequestPeriod : IStringEnum
{
    public static readonly ListNichesRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly ListNichesRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly ListNichesRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public ListNichesRequestPeriod(string value)
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
    public static ListNichesRequestPeriod FromCustom(string value)
    {
        return new ListNichesRequestPeriod(value);
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

    public static bool operator ==(ListNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListNichesRequestPeriod value) => value.Value;

    public static explicit operator ListNichesRequestPeriod(string value) => new(value);

    internal class ListNichesRequestPeriodSerializer : JsonConverter<ListNichesRequestPeriod>
    {
        public override ListNichesRequestPeriod Read(
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
            return new ListNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListNichesRequestPeriod ReadAsPropertyName(
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
            return new ListNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListNichesRequestPeriod value,
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
