using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record BrandsReferenceRequest
{
    /// <summary>
    /// Maximum number of brands (maximum 100).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Text in the brand name, at least 2 characters. Upper and lower case are the same.
    /// </summary>
    [JsonIgnore]
    public required string Search { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
