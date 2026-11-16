using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VisibilityHistoryTest : BaseMockServerTest
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
                  "date": "2023-01-15",
                  "markets": {
                    "NL": {
                      "categoryImpressions": 1.1,
                      "keywordImpressions": 1.1
                    },
                    "BE": {
                      "categoryImpressions": 1.1,
                      "keywordImpressions": 1.1
                    }
                  }
                },
                {
                  "date": "2023-01-15",
                  "markets": {
                    "NL": {
                      "categoryImpressions": 1.1,
                      "keywordImpressions": 1.1
                    },
                    "BE": {
                      "categoryImpressions": 1.1,
                      "keywordImpressions": 1.1
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
                    .WithPath("/api/public/v1/research/products/productCode/visibility-history/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.VisibilityHistoryAsync(
            new VisibilityHistoryProductsRequest { ProductCode = "productCode" }
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
                  "date": "2026-08-01",
                  "markets": {
                    "NL": {
                      "categoryImpressions": 4005,
                      "keywordImpressions": 2309
                    },
                    "BE": {
                      "categoryImpressions": 3239,
                      "keywordImpressions": 3358
                    }
                  }
                },
                {
                  "date": "2026-09-01",
                  "markets": {
                    "NL": {
                      "categoryImpressions": 1590,
                      "keywordImpressions": 1594
                    },
                    "BE": {
                      "categoryImpressions": 1074,
                      "keywordImpressions": 2125
                    }
                  }
                },
                {
                  "date": "2026-10-01",
                  "markets": {
                    "NL": {
                      "categoryImpressions": 998,
                      "keywordImpressions": 1197
                    },
                    "BE": {
                      "categoryImpressions": 463,
                      "keywordImpressions": 1226
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
                    .WithPath(
                        "/api/public/v1/research/products/9300000138905032/visibility-history/"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.VisibilityHistoryAsync(
            new VisibilityHistoryProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
