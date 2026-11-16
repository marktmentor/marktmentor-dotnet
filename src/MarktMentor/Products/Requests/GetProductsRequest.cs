using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record GetProductsRequest
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
    public GetProductsRequestMarket? Market { get; set; }

    /// <summary>
    /// * `30d` - 30d
    /// * `90d` - 90d
    /// * `365d` - 365d
    /// </summary>
    [JsonIgnore]
    public GetProductsRequestPeriod? Period { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
