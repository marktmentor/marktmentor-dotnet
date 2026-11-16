using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StorePerformanceReturnCostsBreakdown : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("otherReturnCosts")]
    public required double OtherReturnCosts { get; set; }

    [JsonPropertyName("returnLabelCost")]
    public required double ReturnLabelCost { get; set; }

    [JsonPropertyName("productLostLeniency")]
    public required double ProductLostLeniency { get; set; }

    [JsonPropertyName("otherCompensation")]
    public required double OtherCompensation { get; set; }

    [JsonPropertyName("commissionCorrection")]
    public required double CommissionCorrection { get; set; }

    [JsonPropertyName("revenueCorrection")]
    public required double RevenueCorrection { get; set; }

    [JsonPropertyName("shipAdditionalProducts")]
    public required double ShipAdditionalProducts { get; set; }

    [JsonPropertyName("productsBackInStockCorrection")]
    public required double ProductsBackInStockCorrection { get; set; }

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
