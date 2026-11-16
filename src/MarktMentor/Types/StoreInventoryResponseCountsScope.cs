using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(
    typeof(StoreInventoryResponseCountsScope.StoreInventoryResponseCountsScopeSerializer)
)]
[Serializable]
public readonly record struct StoreInventoryResponseCountsScope : IStringEnum
{
    public static readonly StoreInventoryResponseCountsScope ResolvedPage = new(
        Values.ResolvedPage
    );

    public static readonly StoreInventoryResponseCountsScope ResolvedCatalogue = new(
        Values.ResolvedCatalogue
    );

    public StoreInventoryResponseCountsScope(string value)
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
    public static StoreInventoryResponseCountsScope FromCustom(string value)
    {
        return new StoreInventoryResponseCountsScope(value);
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

    public static bool operator ==(StoreInventoryResponseCountsScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StoreInventoryResponseCountsScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StoreInventoryResponseCountsScope value) => value.Value;

    public static explicit operator StoreInventoryResponseCountsScope(string value) => new(value);

    internal class StoreInventoryResponseCountsScopeSerializer
        : JsonConverter<StoreInventoryResponseCountsScope>
    {
        public override StoreInventoryResponseCountsScope Read(
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
            return new StoreInventoryResponseCountsScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StoreInventoryResponseCountsScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StoreInventoryResponseCountsScope ReadAsPropertyName(
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
            return new StoreInventoryResponseCountsScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StoreInventoryResponseCountsScope value,
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
        public const string ResolvedPage = "resolved_page";

        public const string ResolvedCatalogue = "resolved_catalogue";
    }
}
