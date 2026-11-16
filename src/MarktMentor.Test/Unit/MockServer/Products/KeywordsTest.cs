using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class KeywordsTest : BaseMockServerTest
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
                  "keywordId": "keywordId",
                  "keyword": "keyword",
                  "markets": {
                    "NL": {
                      "searchVolume": 1.1,
                      "position": 1.1
                    },
                    "BE": {
                      "searchVolume": 1.1,
                      "position": 1.1
                    }
                  }
                },
                {
                  "keywordId": "keywordId",
                  "keyword": "keyword",
                  "markets": {
                    "NL": {
                      "searchVolume": 1.1,
                      "position": 1.1
                    },
                    "BE": {
                      "searchVolume": 1.1,
                      "position": 1.1
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
                    .WithPath("/api/public/v1/research/products/productCode/keywords/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.KeywordsAsync(
            new KeywordsProductsRequest { ProductCode = "productCode" }
        );
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
                  "keywordId": "5150",
                  "keyword": "duurzaam",
                  "markets": {
                    "NL": {},
                    "BE": {
                      "searchVolume": 6,
                      "position": 91
                    }
                  }
                },
                {
                  "keywordId": "6797",
                  "keyword": "drinkfles",
                  "markets": {
                    "NL": {
                      "searchVolume": 6286,
                      "position": 84
                    },
                    "BE": {
                      "searchVolume": 2332,
                      "position": 10
                    }
                  }
                },
                {
                  "keywordId": "6800",
                  "keyword": "drinkfles volwassenen",
                  "markets": {
                    "NL": {},
                    "BE": {
                      "searchVolume": 21,
                      "position": 30
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
                    .WithPath("/api/public/v1/research/products/9300000138905032/keywords/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.KeywordsAsync(
            new KeywordsProductsRequest { ProductCode = "9300000138905032" }
        );
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
                  "keywordId": "keywordId",
                  "keyword": "keyword",
                  "markets": {}
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/keywords/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.KeywordsAsync(
            new KeywordsProductsRequest { ProductCode = "9300000138905032" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
