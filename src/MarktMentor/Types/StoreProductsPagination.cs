using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreProductsPagination : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("page")]
    public required int Page { get; set; }

    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

    /// <summary>
    /// Number of selected products with orders in the period. This is not the size of the catalog. null: the page is empty and it is not the first page, thus the total is unknown.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("hasNext")]
    public required bool HasNext { get; set; }

    /// <summary>
    /// True when the total is unknown or is 1,000 or more. The source selects at most 1,000 EANs: the selection can then be incomplete. Use the EAN or category filter to make it smaller.
    /// </summary>
    [JsonPropertyName("totalMayBeCapped")]
    public required bool TotalMayBeCapped { get; set; }

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
