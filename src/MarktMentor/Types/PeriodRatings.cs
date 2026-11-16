using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record PeriodRatings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("1")]
    public int? _1 { get; set; }

    [JsonPropertyName("2")]
    public int? _2 { get; set; }

    [JsonPropertyName("3")]
    public int? _3 { get; set; }

    [JsonPropertyName("4")]
    public int? _4 { get; set; }

    [JsonPropertyName("5")]
    public int? _5 { get; set; }

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
