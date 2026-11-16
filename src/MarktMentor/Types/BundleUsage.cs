using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record BundleUsage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Requests included in the current billing period.
    /// </summary>
    [JsonPropertyName("includedRequests")]
    public required int IncludedRequests { get; set; }

    /// <summary>
    /// Successful research requests charged in this period.
    /// </summary>
    [JsonPropertyName("usedRequests")]
    public required int UsedRequests { get; set; }

    /// <summary>
    /// Included requests left in this period.
    /// </summary>
    [JsonPropertyName("remainingRequests")]
    public required int RemainingRequests { get; set; }

    /// <summary>
    /// Requests above the included amount, billed at €0.05 each.
    /// </summary>
    [JsonPropertyName("additionalRequests")]
    public required int AdditionalRequests { get; set; }

    /// <summary>
    /// Most the organization pays for requests above the bundle in one billing period, in euro cents. 0 (the default): requests stop when the bundle is used up and return 402 `bundle_exhausted`. Above 0: extra requests are allowed up to this amount, then return 402 `overage_limit_reached`.
    /// </summary>
    [JsonPropertyName("additionalRequestsLimitAmount")]
    public required int AdditionalRequestsLimitAmount { get; set; }

    [JsonPropertyName("periodStart")]
    public required DateTime PeriodStart { get; set; }

    /// <summary>
    /// The included requests reset at this time.
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public required DateTime PeriodEnd { get; set; }

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
