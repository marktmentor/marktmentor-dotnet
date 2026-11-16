using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[JsonConverter(typeof(InventoryStoreRequestStockState.InventoryStoreRequestStockStateSerializer))]
[Serializable]
public readonly record struct InventoryStoreRequestStockState : IStringEnum
{
    public static readonly InventoryStoreRequestStockState OutOfStock = new(Values.OutOfStock);

    public static readonly InventoryStoreRequestStockState Low = new(Values.Low);

    public static readonly InventoryStoreRequestStockState Ok = new(Values.Ok);

    public InventoryStoreRequestStockState(string value)
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
    public static InventoryStoreRequestStockState FromCustom(string value)
    {
        return new InventoryStoreRequestStockState(value);
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

    public static bool operator ==(InventoryStoreRequestStockState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryStoreRequestStockState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryStoreRequestStockState value) => value.Value;

    public static explicit operator InventoryStoreRequestStockState(string value) => new(value);

    internal class InventoryStoreRequestStockStateSerializer
        : JsonConverter<InventoryStoreRequestStockState>
    {
        public override InventoryStoreRequestStockState Read(
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
            return new InventoryStoreRequestStockState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InventoryStoreRequestStockState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override InventoryStoreRequestStockState ReadAsPropertyName(
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
            return new InventoryStoreRequestStockState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            InventoryStoreRequestStockState value,
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
    }
}
