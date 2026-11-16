using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CategoryRankingsTest : BaseMockServerTest
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
                  "categoryId": 1,
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
                  "categoryId": 1,
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
                    .WithPath("/api/public/v1/research/products/productCode/category-rankings/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.CategoryRankingsAsync(
            new CategoryRankingsProductsRequest { ProductCode = "productCode" }
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
                  "categoryId": 11764,
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "NL": 601.0714285714286,
                        "BE": 84.53571428571429
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "NL": 203.8,
                        "BE": 10.451612903225806
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {
                        "NL": 533.375,
                        "BE": 34.0625
                      }
                    }
                  ]
                },
                {
                  "categoryId": 15270,
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "NL": 502.92857142857144,
                        "BE": 120.35714285714286
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "NL": 114.6,
                        "BE": 9.03225806451613
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {
                        "NL": 237.4375,
                        "BE": 20.15625
                      }
                    }
                  ]
                },
                {
                  "categoryId": 15296,
                  "history": [
                    {
                      "date": "2026-08-01",
                      "positions": {
                        "NL": 90.41176470588235,
                        "BE": 24.294117647058822
                      }
                    },
                    {
                      "date": "2026-09-01",
                      "positions": {
                        "NL": 35.827586206896555,
                        "BE": 7.758620689655173
                      }
                    },
                    {
                      "date": "2026-10-01",
                      "positions": {
                        "NL": 53.05263157894737,
                        "BE": 9.578947368421053
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
                    .WithPath(
                        "/api/public/v1/research/products/9300000138905032/category-rankings/"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.CategoryRankingsAsync(
            new CategoryRankingsProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
