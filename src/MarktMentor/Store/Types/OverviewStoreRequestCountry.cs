using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(OverviewStoreRequestCountry.OverviewStoreRequestCountrySerializer))]
[Serializable]
public readonly record struct OverviewStoreRequestCountry : IStringEnum
{
    public static readonly OverviewStoreRequestCountry Nl = new(Values.Nl);

    public static readonly OverviewStoreRequestCountry Be = new(Values.Be);

    public static readonly OverviewStoreRequestCountry Empty = new(Values.Empty);

    public OverviewStoreRequestCountry(string value)
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
    public static OverviewStoreRequestCountry FromCustom(string value)
    {
        return new OverviewStoreRequestCountry(value);
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

    public static bool operator ==(OverviewStoreRequestCountry value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OverviewStoreRequestCountry value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OverviewStoreRequestCountry value) => value.Value;

    public static explicit operator OverviewStoreRequestCountry(string value) => new(value);

    internal class OverviewStoreRequestCountrySerializer
        : JsonConverter<OverviewStoreRequestCountry>
    {
        public override OverviewStoreRequestCountry Read(
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
            return new OverviewStoreRequestCountry(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OverviewStoreRequestCountry value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OverviewStoreRequestCountry ReadAsPropertyName(
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
            return new OverviewStoreRequestCountry(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OverviewStoreRequestCountry value,
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

        public const string Empty = "";
    }
}
