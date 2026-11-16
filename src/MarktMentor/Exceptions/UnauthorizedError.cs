namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
