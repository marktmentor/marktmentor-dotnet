using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreKpi : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("revenue")]
    public double? Revenue { get; set; }

    [JsonPropertyName("netRevenue")]
    public double? NetRevenue { get; set; }

    [JsonPropertyName("costs")]
    public double? Costs { get; set; }

    [JsonPropertyName("profit")]
    public double? Profit { get; set; }

    [JsonPropertyName("orders")]
    public int? Orders { get; set; }

    [JsonPropertyName("sales")]
    public int? Sales { get; set; }

    [JsonPropertyName("returns")]
    public double? Returns { get; set; }

    [JsonPropertyName("adCosts")]
    public double? AdCosts { get; set; }

    /// <summary>
    /// Advertising cost divided by the revenue of the whole store. Percentage: 9.0 is 9%.
    /// </summary>
    [JsonPropertyName("storeTacos")]
    public double? StoreTacos { get; set; }

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
