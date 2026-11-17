# MarktMentor

Official C# SDK for the [MarktMentor Public API](https://api.marktmentor.nl):
bol product research and your own store data. Targets .NET 8, .NET Framework
4.6.2 and .NET Standard 2.0.

```sh
dotnet add package MarktMentor
```

```csharp
using MarktMentor;

var client = new MarktMentorClient(Environment.GetEnvironmentVariable("MARKTMENTOR_API_KEY"));

try
{
    var products = await client.Products.ListAsync(new ListProductsRequest { Search = "drinkfles" });
    await foreach (var product in products) // all pages
    {
        Console.WriteLine($"{product.ProductCode} {product.Title}");
    }
    var history = await client.Products.SalesHistoryAsync(
        new SalesHistoryProductsRequest
        {
            ProductCode = "ean:8712345678901",
            Period = SalesHistoryProductsRequestPeriod.OneY,
            Interval = SalesHistoryProductsRequestInterval.Month,
        }
    );
}
catch (PaymentRequiredError error)
{
    Console.WriteLine($"Allowance used up: {error.Body.Code}");
}
```

Spending is limited by your account setting, not by the SDK: extra usage above
the bundle is off by default, and the organization owner sets a monthly maximum
in the dashboard. A used-up allowance throws `PaymentRequiredError`;
`error.Body.Code` is `BundleExhausted`, `OverageLimitReached` or
`FreeQuotaExhausted`. The generated reference is in `reference.md`.
