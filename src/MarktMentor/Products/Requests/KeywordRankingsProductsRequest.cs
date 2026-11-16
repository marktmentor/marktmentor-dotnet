using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record KeywordRankingsProductsRequest
{
    /// <summary>
    /// Bol product identifier, returned as productCode. Or `ean:` with a 13-digit EAN, for example `ean:8712345678901`: the API then uses the product with that EAN. When more than one product has the EAN, the request gets HTTP 409 with the candidate product codes.
    /// </summary>
    [JsonIgnore]
    public required string ProductCode { get; set; }

    /// <summary>
    /// Bucket size. With period=2Y, use month.
    ///
    /// * `week` - week
    /// * `month` - month
    /// </summary>
    [JsonIgnore]
    public KeywordRankingsProductsRequestInterval? Interval { get; set; }

    /// <summary>
    /// Up to 25 keywordId values from the keywords endpoint, separated by commas. Without it, the response has the 10 keywords of the keywords endpoint with the highest search volume in the last 30 days.
    /// </summary>
    [JsonIgnore]
    public string? KeywordIds { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public KeywordRankingsProductsRequestMarket? Market { get; set; }

    /// <summary>
    /// * `3M` - 3M
    /// * `6M` - 6M
    /// * `1Y` - 1Y
    /// * `2Y` - 2Y
    /// </summary>
    [JsonIgnore]
    public KeywordRankingsProductsRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
