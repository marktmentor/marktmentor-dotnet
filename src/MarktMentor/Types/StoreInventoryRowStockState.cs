using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(StoreInventoryRowStockState.StoreInventoryRowStockStateSerializer))]
[Serializable]
public readonly record struct StoreInventoryRowStockState : IStringEnum
{
    public static readonly StoreInventoryRowStockState OutOfStock = new(Values.OutOfStock);

    public static readonly StoreInventoryRowStockState Low = new(Values.Low);

    public static readonly StoreInventoryRowStockState Ok = new(Values.Ok);

    public static readonly StoreInventoryRowStockState Unknown = new(Values.Unknown);

    public StoreInventoryRowStockState(string value)
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
    public static StoreInventoryRowStockState FromCustom(string value)
    {
        return new StoreInventoryRowStockState(value);
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

    public static bool operator ==(StoreInventoryRowStockState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StoreInventoryRowStockState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StoreInventoryRowStockState value) => value.Value;

    public static explicit operator StoreInventoryRowStockState(string value) => new(value);

    internal class StoreInventoryRowStockStateSerializer
        : JsonConverter<StoreInventoryRowStockState>
    {
        public override StoreInventoryRowStockState Read(
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
            return new StoreInventoryRowStockState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StoreInventoryRowStockState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StoreInventoryRowStockState ReadAsPropertyName(
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
            return new StoreInventoryRowStockState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StoreInventoryRowStockState value,
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
        public const string OutOfStock = "out_of_stock";

        public const string Low = "low";

        public const string Ok = "ok";

        public const string Unknown = "unknown";
    }
}
