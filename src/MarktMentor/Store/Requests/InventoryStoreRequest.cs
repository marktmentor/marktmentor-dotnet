using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record InventoryStoreRequest
{
    /// <summary>
    /// Only the product with this EAN.
    /// </summary>
    [JsonIgnore]
    public string? Ean { get; set; }

    /// <summary>
    /// Page number, starting at 1.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Results per page (maximum 100).
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// out_of_stock: the stock is zero. low: the stock is 5 or less. ok: more than 5.
    ///
    /// * `out_of_stock` - out_of_stock
    /// * `low` - low
    /// * `ok` - ok
    /// </summary>
    [JsonIgnore]
    public InventoryStoreRequestStockState? StockState { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
