using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ListNichesRequest
{
    /// <summary>
    /// Filter by a bol category identifier. Find it with List categories, or copy it from `categories` of a product.
    /// </summary>
    [JsonIgnore]
    public int? CategoryId { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public ListNichesRequestMarket? Market { get; set; }

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
    /// * `30d` - 30d
    /// * `90d` - 90d
    /// * `365d` - 365d
    /// </summary>
    [JsonIgnore]
    public ListNichesRequestPeriod? Period { get; set; }

    /// <summary>
    /// Text to search for. In product lists, all words must match; the search also matches seller names, EANs and product codes. In review lists, each word must occur in the review text; upper and lower case do not matter.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// * `revenue` - revenue
    /// * `-revenue` - -revenue
    /// * `volume` - volume
    /// * `-volume` - -volume
    /// * `products` - products
    /// * `-products` - -products
    /// </summary>
    [JsonIgnore]
    public ListNichesRequestSort? Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
