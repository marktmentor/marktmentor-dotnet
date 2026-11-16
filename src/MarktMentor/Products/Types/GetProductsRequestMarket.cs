using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(GetProductsRequestMarket.GetProductsRequestMarketSerializer))]
[Serializable]
public readonly record struct GetProductsRequestMarket : IStringEnum
{
    public static readonly GetProductsRequestMarket Nl = new(Values.Nl);

    public static readonly GetProductsRequestMarket Be = new(Values.Be);

    public static readonly GetProductsRequestMarket All = new(Values.All);

    public GetProductsRequestMarket(string value)
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
    public static GetProductsRequestMarket FromCustom(string value)
    {
        return new GetProductsRequestMarket(value);
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

    public static bool operator ==(GetProductsRequestMarket value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetProductsRequestMarket value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetProductsRequestMarket value) => value.Value;

    public static explicit operator GetProductsRequestMarket(string value) => new(value);

    internal class GetProductsRequestMarketSerializer : JsonConverter<GetProductsRequestMarket>
    {
        public override GetProductsRequestMarket Read(
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
            return new GetProductsRequestMarket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetProductsRequestMarket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetProductsRequestMarket ReadAsPropertyName(
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
            return new GetProductsRequestMarket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetProductsRequestMarket value,
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
