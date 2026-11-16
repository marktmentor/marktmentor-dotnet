using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductMarketMetrics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("sales")]
    public double? Sales { get; set; }

    [JsonPropertyName("revenue")]
    public double? Revenue { get; set; }

    [JsonPropertyName("impressions")]
    public double? Impressions { get; set; }

    [JsonPropertyName("sellerCount")]
    public int? SellerCount { get; set; }

    /// <summary>
    /// Search terms the product ranked for in the period.
    /// </summary>
    [JsonPropertyName("searchTermCount")]
    public double? SearchTermCount { get; set; }

    /// <summary>
    /// Average promised delivery time in days.
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
