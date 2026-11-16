using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record SalesHistoryProductsRequest
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
    public SalesHistoryProductsRequestInterval? Interval { get; set; }

    /// <summary>
    /// NL for the Netherlands, BE for Belgium, or ALL for both markets. Reviews support ALL only.
    /// </summary>
    [JsonIgnore]
    public SalesHistoryProductsRequestMarket? Market { get; set; }

    /// <summary>
    /// * `3M` - 3M
    /// * `6M` - 6M
    /// * `1Y` - 1Y
    /// * `2Y` - 2Y
    /// </summary>
    [JsonIgnore]
    public SalesHistoryProductsRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
