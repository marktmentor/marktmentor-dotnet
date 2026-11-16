using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductListResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// * `NL` - NL
    /// * `BE` - BE
    /// * `ALL` - ALL
    /// </summary>
    [JsonPropertyName("market")]
    public required ProductListResponseMarket Market { get; set; }

    [JsonPropertyName("period")]
    public required string Period { get; set; }

    [JsonPropertyName("pagination")]
    public required Pagination Pagination { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<ProductItem> Data { get; set; } = new List<ProductItem>();

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
