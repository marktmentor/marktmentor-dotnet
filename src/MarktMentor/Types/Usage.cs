using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record Usage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("organization")]
    public required UsageOrganization Organization { get; set; }

    /// <summary>
    /// oauth for a portal or app connection, key for an API key.
    ///
    /// * `oauth` - oauth
    /// * `key` - key
    /// </summary>
    [JsonPropertyName("credential")]
    public required UsageCredential Credential { get; set; }

    /// <summary>
    /// bundle: requests count toward the API bundle. unmetered: a grant without a request limit. free: the free monthly allowance. none: research requests are not available.
    ///
    /// * `bundle` - bundle
    /// * `unmetered` - unmetered
    /// * `free` - free
    /// * `none` - none
    /// </summary>
    [JsonPropertyName("plan")]
    public required UsagePlan Plan { get; set; }

    [JsonPropertyName("bundle")]
    public BundleUsage? Bundle { get; set; }

    /// <summary>
    /// The free monthly allowance of the organization, shared by its API keys and portal connections. Absent when the plan does not allow it.
    /// </summary>
    [JsonPropertyName("freeTier")]
    public FreeTierUsage? FreeTier { get; set; }

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
