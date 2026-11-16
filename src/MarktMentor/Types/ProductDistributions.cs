using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductDistributions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("price")]
    public IEnumerable<DistributionBucket> Price { get; set; } = new List<DistributionBucket>();

    [JsonPropertyName("sales")]
    public IEnumerable<DistributionBucket> Sales { get; set; } = new List<DistributionBucket>();

    [JsonPropertyName("revenue")]
    public IEnumerable<DistributionBucket> Revenue { get; set; } = new List<DistributionBucket>();

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
