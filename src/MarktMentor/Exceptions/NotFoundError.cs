namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(ResearchError body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("NotFoundError", 404, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ResearchError Body => body;
}
