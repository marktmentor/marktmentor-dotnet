using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StorePerformanceProductPerformanceItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("ean")]
    public required string Ean { get; set; }

    [JsonPropertyName("inSelectedStore")]
    public bool? InSelectedStore { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    /// <summary>
    /// Average review rating, in stars from 1 to 5. 0 without reviews.
    /// </summary>
    [JsonPropertyName("reviewScore")]
    public double? ReviewScore { get; set; }

    [JsonPropertyName("reviewCount")]
    public int? ReviewCount { get; set; }

    [JsonPropertyName("productLink")]
    public string? ProductLink { get; set; }

    [JsonPropertyName("productCode")]
    public string? ProductCode { get; set; }

    [JsonPropertyName("sales")]
    public double? Sales { get; set; }

    [JsonPropertyName("orders")]
    public double? Orders { get; set; }

    [JsonPropertyName("revenue")]
    public double? Revenue { get; set; }

    [JsonPropertyName("netRevenue")]
    public double? NetRevenue { get; set; }

    [JsonPropertyName("commission")]
    public double? Commission { get; set; }

    [JsonPropertyName("totalCosts")]
    public double? TotalCosts { get; set; }

    [JsonPropertyName("salesCosts")]
    public double? SalesCosts { get; set; }

    [JsonPropertyName("salesCostsBreakdown")]
    public StorePerformanceSalesCostsBreakdown? SalesCostsBreakdown { get; set; }

    [JsonPropertyName("salesProfits")]
    public double? SalesProfits { get; set; }

    /// <summary>
    /// Profit on sales divided by the revenue. Percentage: 25.0 is 25%.
    /// </summary>
    [JsonPropertyName("salesProfitMargin")]
    public double? SalesProfitMargin { get; set; }

    /// <summary>
    /// Profit on sales divided by the sales costs. Percentage: 25.0 is 25%; it can be above 100.
    /// </summary>
    [JsonPropertyName("salesRoi")]
    public double? SalesRoi { get; set; }

    [JsonPropertyName("returns")]
    public double? Returns { get; set; }

    [JsonPropertyName("returnCosts")]
    public double? ReturnCosts { get; set; }

    [JsonPropertyName("returnCostsBreakdown")]
    public StorePerformanceReturnCostsBreakdown? ReturnCostsBreakdown { get; set; }

    [JsonPropertyName("totalProfits")]
    public double? TotalProfits { get; set; }

    /// <summary>
    /// Total profit (after returns, advertising and storage) divided by the net revenue. Percentage: 25.0 is 25%. For a row without returns, advertising and storage costs the divisor can be the revenue.
    /// </summary>
    [JsonPropertyName("totalMargin")]
    public double? TotalMargin { get; set; }

    /// <summary>
    /// Total profit divided by the total costs. Percentage: 25.0 is 25%; it can be above 100.
    /// </summary>
    [JsonPropertyName("totalRoi")]
    public double? TotalRoi { get; set; }

    [JsonPropertyName("clicks")]
    public double? Clicks { get; set; }

    /// <summary>
    /// Orders divided by the visits (clicks). Percentage: 5.0 is 5%.
    /// </summary>
    [JsonPropertyName("conversion")]
    public double? Conversion { get; set; }

    /// <summary>
    /// Conversion of the product group. Percentage: 6.4 is 6.4%, the same unit as conversion. Null when there is no benchmark.
    /// </summary>
    [JsonPropertyName("conversionBenchmark")]
    public double? ConversionBenchmark { get; set; }

    [JsonPropertyName("adCost")]
    public double? AdCost { get; set; }

    /// <summary>
    /// Advertising cost divided by the advertising revenue. Percentage: 8.0 is 8%; it can be above 100. The advertising cost of today is left out, because there is no advertising revenue for today yet; adCost includes today. 0 without advertising revenue.
    /// </summary>
    [JsonPropertyName("acos")]
    public double? Acos { get; set; }

    /// <summary>
    /// Advertising cost divided by the total revenue. Percentage: 4.0 is 4%.
    /// </summary>
    [JsonPropertyName("tacos")]
    public double? Tacos { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("storageCosts")]
    public double? StorageCosts { get; set; }

    [JsonPropertyName("gradedStorageCosts")]
    public double? GradedStorageCosts { get; set; }

    /// <summary>
    /// False when no purchase price is known for the EAN, or when costs are hidden. The profit is then the revenue minus bol costs only.
    /// </summary>
    [JsonPropertyName("hasProductCosts")]
    public required bool HasProductCosts { get; set; }

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
