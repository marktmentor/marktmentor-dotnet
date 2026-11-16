using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(VisibilityHistoryProductsRequestMarket.VisibilityHistoryProductsRequestMarketSerializer)
)]
[Serializable]
public readonly record struct VisibilityHistoryProductsRequestMarket : IStringEnum
{
    public static readonly VisibilityHistoryProductsRequestMarket Nl = new(Values.Nl);

    public static readonly VisibilityHistoryProductsRequestMarket Be = new(Values.Be);

    public static readonly VisibilityHistoryProductsRequestMarket All = new(Values.All);

    public VisibilityHistoryProductsRequestMarket(string value)
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
    public static VisibilityHistoryProductsRequestMarket FromCustom(string value)
    {
        return new VisibilityHistoryProductsRequestMarket(value);
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

    public static bool operator ==(VisibilityHistoryProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VisibilityHistoryProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VisibilityHistoryProductsRequestMarket value) =>
        value.Value;

    public static explicit operator VisibilityHistoryProductsRequestMarket(string value) =>
        new(value);

    internal class VisibilityHistoryProductsRequestMarketSerializer
        : JsonConverter<VisibilityHistoryProductsRequestMarket>
    {
        public override VisibilityHistoryProductsRequestMarket Read(
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
            return new VisibilityHistoryProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VisibilityHistoryProductsRequestMarket ReadAsPropertyName(
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
            return new VisibilityHistoryProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VisibilityHistoryProductsRequestMarket value,
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

        public const string All = "ALL";
    }
}
