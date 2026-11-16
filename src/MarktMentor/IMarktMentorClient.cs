namespace MarktMentor;

public partial interface IMarktMentorClient
{
    public IProductsClient Products { get; }
    public INichesClient Niches { get; }
    public IReferenceClient Reference { get; }
    public IOrganizationClient Organization { get; }
    public IUsageClient Usage { get; }
    public IStoreClient Store { get; }
}
