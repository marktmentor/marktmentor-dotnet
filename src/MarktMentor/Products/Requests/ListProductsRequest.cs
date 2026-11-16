using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ListProductsRequest
{
    /// <summary>
    /// Filter by brand name. The match is exact, upper and lower case included. Find the name with Search brands, or copy `brand` from a product.
    /// </summary>
    [JsonIgnore]
    public string? Brand { get; set; }

    /// <summary>
    /// Filter by a bol category identifier. Find it with List categories, or copy it from `categories` of a product.
    /// </summary>
    [JsonIgnore]
    public int? CategoryId { get; set; }

    /// <summary>
    /// Filter by a 13-digit EAN, including matching product variants.
    /// </summary>
    [JsonIgnore]
    public string? Ean { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public ListProductsRequestMarket? Market { get; set; }

    [JsonIgnore]
    public double? MaxPrice { get; set; }

    [JsonIgnore]
    public double? MaxRating { get; set; }

    [JsonIgnore]
    public double? MaxRevenue { get; set; }

    [JsonIgnore]
    public double? MaxSales { get; set; }

    [JsonIgnore]
    public double? MinPrice { get; set; }

    [JsonIgnore]
    public double? MinRating { get; set; }

    [JsonIgnore]
    public double? MinRevenue { get; set; }

    [JsonIgnore]
    public double? MinSales { get; set; }

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
    public ListProductsRequestPeriod? Period { get; set; }

    /// <summary>
    /// Text to search for. In product lists, all words must match; the search also matches seller names, EANs and product codes. In review lists, each word must occur in the review text; upper and lower case do not matter.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// * `sales` - sales
    /// * `-sales` - -sales
    /// * `revenue` - revenue
    /// * `-revenue` - -revenue
    /// * `price` - price
    /// * `-price` - -price
    /// </summary>
    [JsonIgnore]
    public ListProductsRequestSort? Sort { get; set; }

    /// <summary>
    /// Return the other products in this product's family (its variants). Other filters and sorting still apply.
    /// </summary>
    [JsonIgnore]
    public string? VariantsOf { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
