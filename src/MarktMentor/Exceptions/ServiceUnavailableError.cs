namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse);
