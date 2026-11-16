using global::System.Net.Http;

namespace MarktMentor.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
