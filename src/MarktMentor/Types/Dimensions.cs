using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record Dimensions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("lengthCm")]
    public double? LengthCm { get; set; }

    [JsonPropertyName("widthCm")]
    public double? WidthCm { get; set; }

    [JsonPropertyName("heightCm")]
    public double? HeightCm { get; set; }

    [JsonPropertyName("weightGrams")]
    public double? WeightGrams { get; set; }

    /// <summary>
    /// bol shipping package type, such as Pakket M.
    /// </summary>
    [JsonPropertyName("packageType")]
    public string? PackageType { get; set; }

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
