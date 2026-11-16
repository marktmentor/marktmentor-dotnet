namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class TooManyRequestsError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("TooManyRequestsError", 429, body, rawResponse: rawResponse);
