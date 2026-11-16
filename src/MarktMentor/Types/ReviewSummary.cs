using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Average rating, in stars from 1 to 5.
    /// </summary>
    [JsonPropertyName("averageRating")]
    public double? AverageRating { get; set; }

    /// <summary>
    /// Reviews that MarktMentor holds for this selection. This can be lower than reviewCount of the product object, which is the number bol shows.
    /// </summary>
    [JsonPropertyName("reviewCount")]
    public required int ReviewCount { get; set; }

    [JsonPropertyName("ratings")]
    public IEnumerable<RatingCount> Ratings { get; set; } = new List<RatingCount>();

    [JsonPropertyName("positiveTopics")]
    public IEnumerable<ReviewTopic> PositiveTopics { get; set; } = new List<ReviewTopic>();

    [JsonPropertyName("negativeTopics")]
    public IEnumerable<ReviewTopic> NegativeTopics { get; set; } = new List<ReviewTopic>();

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
