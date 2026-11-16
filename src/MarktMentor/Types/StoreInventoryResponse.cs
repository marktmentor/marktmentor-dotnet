using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreInventoryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("filters")]
    public required StoreInventoryFilters Filters { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<StoreInventoryRow> Data { get; set; } = new List<StoreInventoryRow>();

    [JsonPropertyName("pagination")]
    public required StoreInventoryPagination Pagination { get; set; }

    [JsonPropertyName("counts")]
    public required StoreInventoryCounts Counts { get; set; }

    /// <summary>
    /// resolved_page: the counts are for this page only (no stockState filter). resolved_catalogue: the counts are for all active products (with a stockState filter).
    ///
    /// * `resolved_page` - resolved_page
    /// * `resolved_catalogue` - resolved_catalogue
    /// </summary>
    [JsonPropertyName("countsScope")]
    public required StoreInventoryResponseCountsScope CountsScope { get; set; }

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
