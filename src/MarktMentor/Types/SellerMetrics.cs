using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record SellerMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Share of the measured buy-box time in this market. Percentage: 87.4 is 87.4%. Null when no buy-box time was measured.
    /// </summary>
    [JsonPropertyName("buyBoxShare")]
    public double? BuyBoxShare { get; set; }

    [JsonPropertyName("averagePrice")]
    public double? AveragePrice { get; set; }

    /// <summary>
    /// Most frequent recorded delivery time in days for this market.
    /// </summary>
    [JsonPropertyName("deliveryDays")]
    public double? DeliveryDays { get; set; }

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
