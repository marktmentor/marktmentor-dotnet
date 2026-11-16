using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Stable, opaque identifier of the review. It does not contain the name of the reviewer.
    /// </summary>
    [JsonPropertyName("reviewId")]
    public required string ReviewId { get; set; }

    [JsonPropertyName("productCode")]
    public string? ProductCode { get; set; }

    /// <summary>
    /// Stars of the review, from 1 to 5.
    /// </summary>
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("verifiedPurchase")]
    public bool? VerifiedPurchase { get; set; }

    [JsonPropertyName("helpfulVotes")]
    public int? HelpfulVotes { get; set; }

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
