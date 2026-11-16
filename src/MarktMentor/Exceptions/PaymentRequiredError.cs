namespace MarktMentor;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class PaymentRequiredError(AllowanceError body, MarktMentor.RawResponse? rawResponse = null)
    : MarktMentorClientApiException("PaymentRequiredError", 402, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new AllowanceError Body => body;
}
