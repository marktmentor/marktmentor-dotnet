using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewsNichesRequest
{
    /// <summary>
    /// Niche identifier returned as nicheId by Search niches.
    /// </summary>
    [JsonIgnore]
    public required int NicheId { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public ReviewsNichesRequestMarket? Market { get; set; }

    /// <summary>
    /// Page number, starting at 1.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Results per page (maximum 25). A successful page counts as one request. For each query, page × pageSize must not be more than 10,000; make the query narrower with filters to reach other results.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// * `3M` - 3M
    /// * `6M` - 6M
    /// * `1Y` - 1Y
    /// * `2Y` - 2Y
    /// </summary>
    [JsonIgnore]
    public ReviewsNichesRequestPeriod? Period { get; set; }

    [JsonIgnore]
    public int? Score { get; set; }

    /// <summary>
    /// Text to search for. In product lists, all words must match; the search also matches seller names, EANs and product codes. In review lists, each word must occur in the review text; upper and lower case do not matter.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// * `date` - date
    /// * `-date` - -date
    /// * `score` - score
    /// * `-score` - -score
    /// </summary>
    [JsonIgnore]
    public ReviewsNichesRequestSort? Sort { get; set; }

    [JsonIgnore]
    public bool? Verified { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
