using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record CategoriesReferenceRequest
{
    /// <summary>
    /// Only categories of this level. Level 1 is the top of the tree.
    /// </summary>
    [JsonIgnore]
    public int? Level { get; set; }

    /// <summary>
    /// Page number, starting at 1.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Results per page (maximum 200).
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// Only the categories directly below this category.
    /// </summary>
    [JsonIgnore]
    public int? ParentId { get; set; }

    /// <summary>
    /// Text in the category name. Every word must be in the name. Upper and lower case are the same.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
