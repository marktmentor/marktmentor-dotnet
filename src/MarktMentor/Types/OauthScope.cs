using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(OauthScope.OauthScopeSerializer))]
[Serializable]
public readonly record struct OauthScope : IStringEnum
{
    /// <summary>
    /// Read organization store data
    /// </summary>
    public static readonly OauthScope StoreRead = new(Values.StoreRead);

    /// <summary>
    /// Read Product Research data
    /// </summary>
    public static readonly OauthScope ResearchRead = new(Values.ResearchRead);

    public OauthScope(string value)
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
    public static OauthScope FromCustom(string value)
    {
        return new OauthScope(value);
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

    public static bool operator ==(OauthScope value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OauthScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OauthScope value) => value.Value;

    public static explicit operator OauthScope(string value) => new(value);

    internal class OauthScopeSerializer : JsonConverter<OauthScope>
    {
        public override OauthScope Read(
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
            return new OauthScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OauthScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OauthScope ReadAsPropertyName(
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
            return new OauthScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OauthScope value,
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
        /// <summary>
        /// Read organization store data
        /// </summary>
        public const string StoreRead = "store:read";

        /// <summary>
        /// Read Product Research data
        /// </summary>
        public const string ResearchRead = "research:read";
    }
}
