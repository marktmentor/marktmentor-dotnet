using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreProductsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("period")]
    public required Period Period { get; set; }

    [JsonPropertyName("filters")]
    public required StoreProductsFilters Filters { get; set; }

    /// <summary>
    /// Products with orders in the period, not the full catalog and not a ranking of the most profitable products.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<StorePerformanceProductPerformanceItem> Data { get; set; } =
        new List<StorePerformanceProductPerformanceItem>();

    [JsonPropertyName("pagination")]
    public required StoreProductsPagination Pagination { get; set; }

    /// <summary>
    /// False when product and shipping costs are hidden for this store. The profit is then before those costs.
    /// </summary>
    [JsonPropertyName("costsVisible")]
    public required bool CostsVisible { get; set; }

    [JsonPropertyName("asOf")]
    public required DateTime AsOf { get; set; }

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
