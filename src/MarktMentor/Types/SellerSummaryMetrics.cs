using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record SellerSummaryMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Returned sellers with a positive measured buy-box share. May be incomplete when hasMore is true.
    /// </summary>
    [JsonPropertyName("buyBoxSellerCount")]
    public required int BuyBoxSellerCount { get; set; }

    [JsonPropertyName("buyBoxTakeovers")]
    public int? BuyBoxTakeovers { get; set; }

    [JsonPropertyName("averageHoursInBuyBox")]
    public double? AverageHoursInBuyBox { get; set; }

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
