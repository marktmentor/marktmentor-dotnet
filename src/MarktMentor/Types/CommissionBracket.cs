using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record CommissionBracket : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Applies to sale prices below this amount. Null for the top bracket.
    /// </summary>
    [JsonPropertyName("priceBelow")]
    public double? PriceBelow { get; set; }

    /// <summary>
    /// Fixed fee in euros.
    /// </summary>
    [JsonPropertyName("fixed")]
    public double? Fixed { get; set; }

    /// <summary>
    /// Percentage of the sale price.
    /// </summary>
    [JsonPropertyName("percentage")]
    public double? Percentage { get; set; }

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
