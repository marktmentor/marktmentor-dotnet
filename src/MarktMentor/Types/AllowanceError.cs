using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record AllowanceError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Which allowance is used up. See the description of HTTP 402.
    ///
    /// * `bundle_exhausted` - bundle_exhausted
    /// * `overage_limit_reached` - overage_limit_reached
    /// * `free_quota_exhausted` - free_quota_exhausted
    /// </summary>
    [JsonPropertyName("code")]
    public required AllowanceErrorCode Code { get; set; }

    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

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
