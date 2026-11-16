namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(object body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("ConflictError", 409, body, rawResponse: rawResponse);
