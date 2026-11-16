using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record GetNichesRequest
{
    /// <summary>
    /// Niche identifier returned as nicheId by Search niches.
    /// </summary>
    [JsonIgnore]
    public required int NicheId { get; set; }

    /// <summary>
    /// Include core niche metrics for 30d, 90d and 365d in data.periods.
    /// </summary>
    [JsonIgnore]
    public bool? ComparePeriods { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public GetNichesRequestMarket? Market { get; set; }

    /// <summary>
    /// * `30d` - 30d
    /// * `90d` - 90d
    /// * `365d` - 365d
    /// </summary>
    [JsonIgnore]
    public GetNichesRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
