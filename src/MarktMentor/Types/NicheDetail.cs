using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record NicheDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("nicheId")]
    public required string NicheId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("productCount")]
    public int? ProductCount { get; set; }

    /// <summary>
    /// Score from 0 to 10. Not a percentage.
    /// </summary>
    [JsonPropertyName("qualityScore")]
    public double? QualityScore { get; set; }

    /// <summary>
    /// Score from 0 to 10. Not a percentage.
    /// </summary>
    [JsonPropertyName("competitionScore")]
    public double? CompetitionScore { get; set; }

    [JsonPropertyName("markets")]
    public required NicheMarkets Markets { get; set; }

    [JsonPropertyName("periods")]
    public IEnumerable<NichePeriod>? Periods { get; set; }

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
