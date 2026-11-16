using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record ReviewSummaryNichesRequest
{
    /// <summary>
    /// Niche identifier returned as nicheId by Search niches.
    /// </summary>
    [JsonIgnore]
    public required int NicheId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
