using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(GetNichesRequestPeriod.GetNichesRequestPeriodSerializer))]
[Serializable]
public readonly record struct GetNichesRequestPeriod : IStringEnum
{
    public static readonly GetNichesRequestPeriod ThirtyD = new(Values.ThirtyD);

    public static readonly GetNichesRequestPeriod NinetyD = new(Values.NinetyD);

    public static readonly GetNichesRequestPeriod ThreeHundredSixtyFiveD = new(
        Values.ThreeHundredSixtyFiveD
    );

    public GetNichesRequestPeriod(string value)
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
    public static GetNichesRequestPeriod FromCustom(string value)
    {
        return new GetNichesRequestPeriod(value);
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

    public static bool operator ==(GetNichesRequestPeriod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetNichesRequestPeriod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetNichesRequestPeriod value) => value.Value;

    public static explicit operator GetNichesRequestPeriod(string value) => new(value);

    internal class GetNichesRequestPeriodSerializer : JsonConverter<GetNichesRequestPeriod>
    {
        public override GetNichesRequestPeriod Read(
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
            return new GetNichesRequestPeriod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetNichesRequestPeriod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetNichesRequestPeriod ReadAsPropertyName(
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
            return new GetNichesRequestPeriod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetNichesRequestPeriod value,
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
