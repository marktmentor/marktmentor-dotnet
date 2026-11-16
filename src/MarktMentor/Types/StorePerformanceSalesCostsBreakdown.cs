using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StorePerformanceSalesCostsBreakdown : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("shippingCosts")]
    public required double ShippingCosts { get; set; }

    [JsonPropertyName("surcharge")]
    public required double Surcharge { get; set; }

    [JsonPropertyName("productCosts")]
    public required double ProductCosts { get; set; }

    [JsonPropertyName("surchargeRefunds")]
    public required double SurchargeRefunds { get; set; }

    [JsonPropertyName("shippingLabelRefunds")]
    public required double ShippingLabelRefunds { get; set; }

    [JsonPropertyName("commission")]
    public required double Commission { get; set; }

    [JsonPropertyName("commissionCorrection")]
    public required double CommissionCorrection { get; set; }

    [JsonPropertyName("compensation")]
    public required double Compensation { get; set; }

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
