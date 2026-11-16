using global::System.Text.Json.Serialization;
using MarktMentor.Core;

namespace MarktMentor;

[Serializable]
public record OverviewStoreRequest
{
    /// <summary>
    /// * `NL` - NL
    /// * `BE` - BE
    /// </summary>
    [JsonIgnore]
    public OverviewStoreRequestCountry? Country { get; set; }

    [JsonIgnore]
    public int? Days { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
