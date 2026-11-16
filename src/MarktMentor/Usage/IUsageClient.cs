namespace MarktMentor;

public partial interface IUsageClient
{
    /// <summary>
    /// Get the research requests of the organization in the current period: what the API bundle includes, what is used and what is left, or the state of the free monthly allowance. Use it to stop before the limit.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    WithRawResponseTask<Usage> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
