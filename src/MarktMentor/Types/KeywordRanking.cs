using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record KeywordRanking : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("keywordId")]
    public required string KeywordId { get; set; }

    /// <summary>
    /// Null when the product has no position on the term in the keywords endpoint.
    /// </summary>
    [JsonPropertyName("keyword")]
    public string? Keyword { get; set; }

    [JsonPropertyName("history")]
    public IEnumerable<RankPoint> History { get; set; } = new List<RankPoint>();

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
