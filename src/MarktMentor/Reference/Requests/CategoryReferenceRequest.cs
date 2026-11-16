using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record CategoryReferenceRequest
{
    /// <summary>
    /// Category identifier, returned as categoryId.
    /// </summary>
    [JsonIgnore]
    public required int CategoryId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
