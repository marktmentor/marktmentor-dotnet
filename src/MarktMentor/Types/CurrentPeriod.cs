using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record CurrentPeriod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("startDate")]
    public required DateOnly StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public required DateOnly EndDate { get; set; }

    [JsonPropertyName("days")]
    public required int Days { get; set; }

    [JsonPropertyName("requestedDays")]
    public required int RequestedDays { get; set; }

    [JsonPropertyName("daysCapped")]
    public required bool DaysCapped { get; set; }

    [JsonPropertyName("maxDays")]
    public required int MaxDays { get; set; }

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
