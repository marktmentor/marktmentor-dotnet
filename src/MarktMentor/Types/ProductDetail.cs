using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ProductDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("productCode")]
    public required string ProductCode { get; set; }

    [JsonPropertyName("ean")]
    public string? Ean { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// Name of the product family (its variant group).
    /// </summary>
    [JsonPropertyName("familyName")]
    public string? FamilyName { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("availableSince")]
    public DateOnly? AvailableSince { get; set; }

    /// <summary>
    /// Average rating over all reviews, in stars from 1 to 5.
    /// </summary>
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    /// <summary>
    /// Number of reviews as bol shows it for the product, counted over the product family. The review endpoints can hold fewer reviews.
    /// </summary>
    [JsonPropertyName("reviewCount")]
    public int? ReviewCount { get; set; }

    [JsonPropertyName("periodReviews")]
    public required PeriodReviews PeriodReviews { get; set; }

    /// <summary>
    /// Date of the data snapshot the figures come from.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("categories")]
    public IEnumerable<CategoryItem> Categories { get; set; } = new List<CategoryItem>();

    /// <summary>
    /// Average position in the main category during the period.
    /// </summary>
    [JsonPropertyName("mainCategoryPosition")]
    public double? MainCategoryPosition { get; set; }

    [JsonPropertyName("dimensions")]
    public required Dimensions Dimensions { get; set; }

    /// <summary>
    /// Whether the dimensions fit bol fulfilment (LvB).
    /// </summary>
    [JsonPropertyName("lvbPossible")]
    public bool? LvbPossible { get; set; }

    /// <summary>
    /// bol commission brackets for the product's category, as bol publishes them (including 21% VAT).
    /// </summary>
    [JsonPropertyName("commission")]
    public IEnumerable<CommissionBracket>? Commission { get; set; }

    [JsonPropertyName("markets")]
    public required ProductMarkets Markets { get; set; }

    /// <summary>
    /// Other products in the same family. Search products with variantsOf returns their data in one request.
    /// </summary>
    [JsonPropertyName("variantCodes")]
    public IEnumerable<string> VariantCodes { get; set; } = new List<string>();

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
