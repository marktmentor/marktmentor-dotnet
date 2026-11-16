using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(SalesHistoryProductsRequestMarket.SalesHistoryProductsRequestMarketSerializer)
)]
[Serializable]
public readonly record struct SalesHistoryProductsRequestMarket : IStringEnum
{
    public static readonly SalesHistoryProductsRequestMarket Nl = new(Values.Nl);

    public static readonly SalesHistoryProductsRequestMarket Be = new(Values.Be);

    public static readonly SalesHistoryProductsRequestMarket All = new(Values.All);

    public SalesHistoryProductsRequestMarket(string value)
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
    public static SalesHistoryProductsRequestMarket FromCustom(string value)
    {
        return new SalesHistoryProductsRequestMarket(value);
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

    public static bool operator ==(SalesHistoryProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SalesHistoryProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SalesHistoryProductsRequestMarket value) => value.Value;

    public static explicit operator SalesHistoryProductsRequestMarket(string value) => new(value);

    internal class SalesHistoryProductsRequestMarketSerializer
        : JsonConverter<SalesHistoryProductsRequestMarket>
    {
        public override SalesHistoryProductsRequestMarket Read(
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
            return new SalesHistoryProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SalesHistoryProductsRequestMarket ReadAsPropertyName(
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
            return new SalesHistoryProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SalesHistoryProductsRequestMarket value,
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
