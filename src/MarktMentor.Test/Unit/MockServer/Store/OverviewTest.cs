using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Store;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class OverviewTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "period": {
                "startDate": "2023-01-15",
                "endDate": "2023-01-15",
                "days": 1,
                "requestedDays": 1,
                "daysCapped": true,
                "maxDays": 1
              },
              "previousPeriod": {
                "startDate": "2023-01-15",
                "endDate": "2023-01-15",
                "days": 1
              },
              "filters": {
                "country": "country"
              },
              "kpis": {
                "revenue": 1.1,
                "netRevenue": 1.1,
                "costs": 1.1,
                "profit": 1.1,
                "orders": 1,
                "sales": 1,
                "returns": 1.1,
                "adCosts": 1.1,
                "storeTacos": 1.1
              },
              "previous": {
                "revenue": 1.1,
                "netRevenue": 1.1,
                "costs": 1.1,
                "profit": 1.1,
                "orders": 1,
                "sales": 1,
                "returns": 1.1
              },
              "change": {
                "revenue": 1.1,
                "netRevenue": 1.1,
                "costs": 1.1,
                "profit": 1.1,
                "orders": 1.1,
                "sales": 1.1,
                "returns": 1.1
              },
              "changePct": {
                "revenue": 1.1,
                "netRevenue": 1.1,
                "costs": 1.1,
                "profit": 1.1,
                "orders": 1.1,
                "sales": 1.1,
                "returns": 1.1
              },
              "asOf": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/overview/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Store.OverviewAsync(new OverviewStoreRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "period": {
                "startDate": "2026-08-23",
                "endDate": "2026-09-21",
                "days": 30,
                "requestedDays": 30,
                "daysCapped": false,
                "maxDays": 365
              },
              "previousPeriod": {
                "startDate": "2026-07-24",
                "endDate": "2026-08-22",
                "days": 30
              },
              "filters": {},
              "kpis": {
                "revenue": 12000,
                "netRevenue": 9600,
                "costs": 6000,
                "profit": 3600,
                "orders": 240,
                "sales": 300,
                "returns": 12,
                "adCosts": 1080,
                "storeTacos": 9
              },
              "previous": {
                "revenue": 10000,
                "netRevenue": 8000,
                "costs": 5000,
                "profit": 3000,
                "orders": 200,
                "sales": 250,
                "returns": 10
              },
              "change": {
                "revenue": 2000,
                "netRevenue": 1600,
                "costs": 1000,
                "profit": 600,
                "orders": 40,
                "sales": 50,
                "returns": 2
              },
              "changePct": {
                "revenue": 20,
                "netRevenue": 20,
                "costs": 20,
                "profit": 20,
                "orders": 20,
                "sales": 20,
                "returns": 20
              },
              "asOf": "2026-09-22T08:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/overview/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Store.OverviewAsync(new OverviewStoreRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
