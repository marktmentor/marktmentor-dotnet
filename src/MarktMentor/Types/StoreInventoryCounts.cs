using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record StoreInventoryCounts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("resolved")]
    public required int Resolved { get; set; }

    [JsonPropertyName("outOfStock")]
    public required int OutOfStock { get; set; }

    [JsonPropertyName("low")]
    public required int Low { get; set; }

    [JsonPropertyName("ok")]
    public required int Ok { get; set; }

    [JsonPropertyName("unknown")]
    public required int Unknown { get; set; }

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
