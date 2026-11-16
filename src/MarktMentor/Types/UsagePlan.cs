using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(UsagePlan.UsagePlanSerializer))]
[Serializable]
public readonly record struct UsagePlan : IStringEnum
{
    public static readonly UsagePlan Bundle = new(Values.Bundle);

    public static readonly UsagePlan Unmetered = new(Values.Unmetered);

    public static readonly UsagePlan Free = new(Values.Free);

    public static readonly UsagePlan None = new(Values.None);

    public UsagePlan(string value)
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
    public static UsagePlan FromCustom(string value)
    {
        return new UsagePlan(value);
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

    public static bool operator ==(UsagePlan value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(UsagePlan value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(UsagePlan value) => value.Value;

    public static explicit operator UsagePlan(string value) => new(value);

    internal class UsagePlanSerializer : JsonConverter<UsagePlan>
    {
        public override UsagePlan Read(
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
            return new UsagePlan(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UsagePlan value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UsagePlan ReadAsPropertyName(
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
            return new UsagePlan(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UsagePlan value,
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
        public const string Bundle = "bundle";

        public const string Unmetered = "unmetered";

        public const string Free = "free";

        public const string None = "none";
    }
}
