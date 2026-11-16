using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductsStoreRequest
{
    /// <summary>
    /// Only products in this bol category or in a category below it. The same identifier as `categoryId` in the research filters; find it with List categories.
    /// </summary>
    [JsonIgnore]
    public int? CategoryId { get; set; }

    /// <summary>
    /// NL or BE. Without this parameter: both countries.
    ///
    /// * `NL` - NL
    /// * `BE` - BE
    /// </summary>
    [JsonIgnore]
    public ProductsStoreRequestCountry? Country { get; set; }

    /// <summary>
    /// The last N days, today included. Do not combine with startDate and endDate.
    /// </summary>
    [JsonIgnore]
    public int? Days { get; set; }

    /// <summary>
    /// EANs, separated by commas (maximum 100). With this filter, the page is in the sequence of sales (high to low) and `sort` only selects the products.
    /// </summary>
    [JsonIgnore]
    public string? Eans { get; set; }

    /// <summary>
    /// Last day of the period (YYYY-MM-DD), included.
    /// </summary>
    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// Page number, from 1 to 100.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Results per page: 5, 10, 25, 50 or 100.
    ///
    /// * `5` - 5
    /// * `10` - 10
    /// * `25` - 25
    /// * `50` - 50
    /// * `100` - 100
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Sort field; a `-` prefix gives high to low. Selection and sequence use the order amounts before the final cost adjustments (advertising, storage, returns). Thus the sequence can be different from the sequence of `totalCosts` or `totalProfits`.
    ///
    /// * `revenue` - revenue
    /// * `-revenue` - -revenue
    /// * `sales` - sales
    /// * `-sales` - -sales
    /// * `costs` - costs
    /// * `-costs` - -costs
    /// * `profits` - profits
    /// * `-profits` - -profits
    /// </summary>
    [JsonIgnore]
    public ProductsStoreRequestSort? Sort { get; set; }

    /// <summary>
    /// First day of the period (YYYY-MM-DD). Send it together with endDate. The period can be at most 366 days.
    /// </summary>
    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
