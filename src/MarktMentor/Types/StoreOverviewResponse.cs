using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreOverviewResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("period")]
    public required CurrentPeriod Period { get; set; }

    [JsonPropertyName("previousPeriod")]
    public required Period PreviousPeriod { get; set; }

    [JsonPropertyName("filters")]
    public required StoreFilters Filters { get; set; }

    [JsonPropertyName("kpis")]
    public required StoreKpi Kpis { get; set; }

    [JsonPropertyName("previous")]
    public required StorePreviousKpi Previous { get; set; }

    /// <summary>
    /// The value of this period minus the value of the previous period.
    /// </summary>
    [JsonPropertyName("change")]
    public required StoreChange Change { get; set; }

    /// <summary>
    /// Each value is the change divided by the previous value. Percentage: 20.0 is +20%. A value is null when the previous value is zero or negative (a loss): a percentage of such a value has no meaning. Use change then.
    /// </summary>
    [JsonPropertyName("changePct")]
    public required StoreChange ChangePct { get; set; }

    [JsonPropertyName("asOf")]
    public required DateTime AsOf { get; set; }

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
