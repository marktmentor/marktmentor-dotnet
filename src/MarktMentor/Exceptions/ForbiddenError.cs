namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
