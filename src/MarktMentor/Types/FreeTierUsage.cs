using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record FreeTierUsage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True when the organization has an active paid MarktMentor Premium subscription.
    /// </summary>
    [JsonPropertyName("eligible")]
    public required bool Eligible { get; set; }

    /// <summary>
    /// Free research requests per month.
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    [JsonPropertyName("used")]
    public required int Used { get; set; }

    [JsonPropertyName("remaining")]
    public required int Remaining { get; set; }

    /// <summary>
    /// Maximum results per page on free requests.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

    /// <summary>
    /// Start of the next calendar month (UTC).
    /// </summary>
    [JsonPropertyName("resetsAt")]
    public required DateTime ResetsAt { get; set; }

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
