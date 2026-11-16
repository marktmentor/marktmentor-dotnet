using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class KeywordRankingsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "period": "period",
              "interval": "interval",
              "data": [
                {
                  "keywordId": "keywordId",
                  "keyword": "keyword",
                  "history": [
                    {
                      "date": "2023-01-15",
                      "positions": {
                        "NL": 1.1,
                        "BE": 1.1
                      }
                    },
                    {
                      "date": "2023-01-15",
                      "positions": {
                        "NL": 1.1,
                        "BE": 1.1
                      }
                    }
                  ]
                },
                {
                  "keywordId": "keywordId",
                  "keyword": "keyword",
                  "history": [
                    {
                      "date": "2023-01-15",
                      "positions": {
                        "NL": 1.1,
                        "BE": 1.1
                      }
                    },
                    {
                      "date": "2023-01-15",
                      "positions": {
                        "NL": 1.1,
                        "BE": 1.1
                      }
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/productCode/keyword-rankings/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.KeywordRankingsAsync(
            new KeywordRankingsProductsRequest { ProductCode = "productCode" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "period": "3M",
              "interval": "month",
              "data": [
                {
                  "keywordId": "6797",
                  "keyword": "drinkfles",
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "NL": 80.7,
                        "BE": 21.210526315789473
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "NL": 36.608695652173914,
                        "BE": 5.260869565217392
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {
                        "NL": 47.074074074074076,
                        "BE": 5.185185185185185
                      }
                    }
                  ]
                },
                {
                  "keywordId": "6800",
                  "keyword": "drinkfles volwassenen",
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "NL": 74.44444444444444,
                        "BE": 56.35
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "NL": 90.75,
                        "BE": 20.869565217391305
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {
                        "NL": 95.33333333333333,
                        "BE": 32.18518518518518
                      }
                    }
                  ]
                },
                {
                  "keywordId": "5150",
                  "keyword": "duurzaam",
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "BE": 85.125
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "BE": 91
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {}
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/keyword-rankings/")
                    .WithParam("keywordIds", "6797", "6800", "5150")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.KeywordRankingsAsync(
            new KeywordRankingsProductsRequest
            {
                ProductCode = "9300000138905032",
                KeywordIds = "6797,6800,5150",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
