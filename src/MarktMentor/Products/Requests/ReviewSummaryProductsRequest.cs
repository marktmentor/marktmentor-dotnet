using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewSummaryProductsRequest
{
    /// <summary>
    /// Bol product identifier, returned as productCode. Or `ean:` with a 13-digit EAN, for example `ean:8712345678901`: the API then uses the product with that EAN. When more than one product has the EAN, the request gets HTTP 409 with the candidate product codes.
    /// </summary>
    [JsonIgnore]
    public required string ProductCode { get; set; }

    /// <summary>
    /// true (the default): also the reviews written for other variants of the same product family, as bol shows them on the product page. false: only the reviews written for this product. productCode of each review says for which product it was written.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeVariants { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
