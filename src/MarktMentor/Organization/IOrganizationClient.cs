namespace MarktMentor;

public partial interface IOrganizationClient
{
    /// <summary>
    /// Get the organization that the credential belongs to. Use it to check which organization an API key or a portal connection reads.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    WithRawResponseTask<IEnumerable<Organization>> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
