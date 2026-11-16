using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewHistoryNichesRequest
{
    /// <summary>
    /// Niche identifier returned as nicheId by Search niches.
    /// </summary>
    [JsonIgnore]
    public required int NicheId { get; set; }

    /// <summary>
    /// Bucket size. With period=2Y, use month.
    ///
    /// * `week` - week
    /// * `month` - month
    /// </summary>
    [JsonIgnore]
    public ReviewHistoryNichesRequestInterval? Interval { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public ReviewHistoryNichesRequestMarket? Market { get; set; }

    /// <summary>
    /// * `3M` - 3M
    /// * `6M` - 6M
    /// * `1Y` - 1Y
    /// * `2Y` - 2Y
    /// </summary>
    [JsonIgnore]
    public ReviewHistoryNichesRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
