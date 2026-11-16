using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record SellerResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("market")]
    public required string Market { get; set; }

    [JsonPropertyName("period")]
    public required string Period { get; set; }

    [JsonPropertyName("hasMore")]
    public required bool HasMore { get; set; }

    [JsonPropertyName("markets")]
    public required SellerSummaryMarkets Markets { get; set; }

    [JsonPropertyName("listingChanges")]
    public required ListingChanges ListingChanges { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<SellerItem> Data { get; set; } = new List<SellerItem>();

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
