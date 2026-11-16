using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "period": "period",
              "pagination": {
                "page": 1,
                "pageSize": 1,
                "total": 1,
                "hasNext": true
              },
              "data": [
                {
                  "nicheId": "nicheId",
                  "name": "name",
                  "productCount": 1,
                  "qualityScore": 1.1,
                  "competitionScore": 1.1,
                  "markets": {
                    "NL": {
                      "searchVolume": 1.1,
                      "sales": 1.1,
                      "revenue": 1.1
                    },
                    "BE": {
                      "searchVolume": 1.1,
                      "sales": 1.1,
                      "revenue": 1.1
                    }
                  }
                },
                {
                  "nicheId": "nicheId",
                  "name": "name",
                  "productCount": 1,
                  "qualityScore": 1.1,
                  "competitionScore": 1.1,
                  "markets": {
                    "NL": {
                      "searchVolume": 1.1,
                      "sales": 1.1,
                      "revenue": 1.1
                    },
                    "BE": {
                      "searchVolume": 1.1,
                      "sales": 1.1,
                      "revenue": 1.1
                    }
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ListAsync(new ListNichesRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "period": "30d",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 3,
                "hasNext": false
              },
              "data": [
                {
                  "nicheId": "6797",
                  "name": "drinkfles",
                  "productCount": 25956,
                  "qualityScore": 5.83,
                  "competitionScore": 10,
                  "markets": {
                    "NL": {
                      "searchVolume": 6286,
                      "sales": 32892,
                      "revenue": 728137.05
                    },
                    "BE": {
                      "searchVolume": 2332,
                      "sales": 7810,
                      "revenue": 177062.22
                    }
                  }
                },
                {
                  "nicheId": "4844",
                  "name": "dopper drinkfles",
                  "productCount": 99,
                  "qualityScore": 7.09,
                  "competitionScore": 10,
                  "markets": {
                    "NL": {
                      "searchVolume": 1683,
                      "sales": 7547,
                      "revenue": 167502.55
                    },
                    "BE": {
                      "searchVolume": 499,
                      "sales": 1710,
                      "revenue": 42350.27
                    }
                  }
                },
                {
                  "nicheId": "11966",
                  "name": "camelbak drinkfles",
                  "productCount": 182,
                  "qualityScore": 5.67,
                  "competitionScore": 10,
                  "markets": {
                    "NL": {
                      "searchVolume": 1802,
                      "sales": 2251,
                      "revenue": 58756.63
                    },
                    "BE": {
                      "searchVolume": 139,
                      "sales": 459,
                      "revenue": 11873.05
                    }
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ListAsync(new ListNichesRequest { Search = "drinkfles" });
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "period": "30d",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 0,
                "hasNext": false
              },
              "data": [
                {
                  "nicheId": "nicheId",
                  "name": "name",
                  "productCount": 1,
                  "qualityScore": 1.1,
                  "competitionScore": 1.1,
                  "markets": {}
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ListAsync(new ListNichesRequest { Search = "drinkfles" });
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
