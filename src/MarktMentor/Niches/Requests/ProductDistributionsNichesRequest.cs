using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductDistributionsNichesRequest
{
    /// <summary>
    /// Niche identifier returned as nicheId by Search niches.
    /// </summary>
    [JsonIgnore]
    public required int NicheId { get; set; }

    /// <summary>
    /// * `30d` - 30d
    /// * `90d` - 90d
    /// * `365d` - 365d
    /// </summary>
    [JsonIgnore]
    public ProductDistributionsNichesRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
