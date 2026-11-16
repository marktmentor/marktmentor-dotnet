using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record Category : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The bol category identifier. Use it as `categoryId` in the product, niche and store filters.
    /// </summary>
    [JsonPropertyName("categoryId")]
    public required int CategoryId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Depth in the tree. Level 1 is the top of the tree.
    /// </summary>
    [JsonPropertyName("level")]
    public required int Level { get; set; }

    /// <summary>
    /// The category directly above. Null for a level 1 category.
    /// </summary>
    [JsonPropertyName("parentId")]
    public int? ParentId { get; set; }

    /// <summary>
    /// From the level 1 category down to this category, itself included.
    /// </summary>
    [JsonPropertyName("path")]
    public IEnumerable<CategoryPathItem> Path { get; set; } = new List<CategoryPathItem>();

    /// <summary>
    /// Number of categories directly below. 0: this is a leaf.
    /// </summary>
    [JsonPropertyName("childCount")]
    public required int ChildCount { get; set; }

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
