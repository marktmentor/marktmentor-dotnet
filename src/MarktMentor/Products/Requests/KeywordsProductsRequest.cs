using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record KeywordsProductsRequest
{
    /// <summary>
    /// Bol product identifier, returned as productCode. Or `ean:` with a 13-digit EAN, for example `ean:8712345678901`: the API then uses the product with that EAN. When more than one product has the EAN, the request gets HTTP 409 with the candidate product codes.
    /// </summary>
    [JsonIgnore]
    public required string ProductCode { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public KeywordsProductsRequestMarket? Market { get; set; }

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
    /// * `7d` - 7d
    /// * `30d` - 30d
    /// * `90d` - 90d
    /// </summary>
    [JsonIgnore]
    public KeywordsProductsRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
