namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("BadRequestError", 400, body, rawResponse: rawResponse);
