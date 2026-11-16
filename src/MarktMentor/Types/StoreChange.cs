using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreChange : IJsonOnDeserialized
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
    public double? Orders { get; set; }

    [JsonPropertyName("sales")]
    public double? Sales { get; set; }

    [JsonPropertyName("returns")]
    public double? Returns { get; set; }

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
