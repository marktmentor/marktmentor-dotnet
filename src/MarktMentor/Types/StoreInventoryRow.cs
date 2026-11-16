using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreInventoryRow : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("ean")]
    public required string Ean { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// Stock of the active fulfilment method of the product: the regular stock at bol (LvB / FBB) or the corrected own stock (VvB / FBR). null when the stock is unknown.
    /// </summary>
    [JsonPropertyName("stock")]
    public int? Stock { get; set; }

    /// <summary>
    /// unknown is not zero: see unknownReason.
    ///
    /// * `out_of_stock` - out_of_stock
    /// * `low` - low
    /// * `ok` - ok
    /// * `unknown` - unknown
    /// </summary>
    [JsonPropertyName("stockState")]
    public required StoreInventoryRowStockState StockState { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("stockLastUpdated")]
    public DateTime? StockLastUpdated { get; set; }

    [JsonPropertyName("unknownReason")]
    public string? UnknownReason { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
