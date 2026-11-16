using MarktMentor.Core;

namespace MarktMentor;

public partial class MarktMentorClient : IMarktMentorClient
{
    private readonly RawClient _client;

    public MarktMentorClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "MarktMentor" },
                { "X-Fern-SDK-Version", global::MarktMentor.Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Products = new ProductsClient(_client);
        Niches = new NichesClient(_client);
        Reference = new ReferenceClient(_client);
        Organization = new OrganizationClient(_client);
        Usage = new UsageClient(_client);
        Store = new StoreClient(_client);
    }

    public IProductsClient Products { get; }

    public INichesClient Niches { get; }

    public IReferenceClient Reference { get; }

    public IOrganizationClient Organization { get; }

    public IUsageClient Usage { get; }

    public IStoreClient Store { get; }
}
