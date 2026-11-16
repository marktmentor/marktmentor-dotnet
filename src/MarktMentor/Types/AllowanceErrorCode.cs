using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(AllowanceErrorCode.AllowanceErrorCodeSerializer))]
[Serializable]
public readonly record struct AllowanceErrorCode : IStringEnum
{
    public static readonly AllowanceErrorCode BundleExhausted = new(Values.BundleExhausted);

    public static readonly AllowanceErrorCode OverageLimitReached = new(Values.OverageLimitReached);

    public static readonly AllowanceErrorCode FreeQuotaExhausted = new(Values.FreeQuotaExhausted);

    public AllowanceErrorCode(string value)
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
    public static AllowanceErrorCode FromCustom(string value)
    {
        return new AllowanceErrorCode(value);
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

    public static bool operator ==(AllowanceErrorCode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AllowanceErrorCode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AllowanceErrorCode value) => value.Value;

    public static explicit operator AllowanceErrorCode(string value) => new(value);

    internal class AllowanceErrorCodeSerializer : JsonConverter<AllowanceErrorCode>
    {
        public override AllowanceErrorCode Read(
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
            return new AllowanceErrorCode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AllowanceErrorCode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AllowanceErrorCode ReadAsPropertyName(
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
            return new AllowanceErrorCode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AllowanceErrorCode value,
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
        public const string BundleExhausted = "bundle_exhausted";

        public const string OverageLimitReached = "overage_limit_reached";

        public const string FreeQuotaExhausted = "free_quota_exhausted";
    }
}
