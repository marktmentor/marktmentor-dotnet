using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record DistributionData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Preferred products (no duplicate variants) in the product snapshot of the requested period that match the niche's EANs, including variant EANs. Not restricted to products with sales. It can be much lower than the productCount of Get a niche (example niche 6797: 25,956 in the niche data and 2,934 here).
    /// </summary>
    [JsonPropertyName("productCount")]
    public required int ProductCount { get; set; }

    /// <summary>
    /// Distributions over the total of both markets (NL and BE together). Price is the price of the period, else the current price. Null when there are no EANs.
    /// </summary>
    [JsonPropertyName("total")]
    public ProductDistributions? Total { get; set; }

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
