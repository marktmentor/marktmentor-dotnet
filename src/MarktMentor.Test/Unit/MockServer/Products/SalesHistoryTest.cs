using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SalesHistoryTest : BaseMockServerTest
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
                      "sales": 1.1,
                      "revenue": 1.1,
                      "price": 1.1
                    },
                    "BE": {
                      "sales": 1.1,
                      "revenue": 1.1,
                      "price": 1.1
                    }
                  }
                },
                {
                  "date": "2023-01-15",
                  "markets": {
                    "NL": {
                      "sales": 1.1,
                      "revenue": 1.1,
                      "price": 1.1
                    },
                    "BE": {
                      "sales": 1.1,
                      "revenue": 1.1,
                      "price": 1.1
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
                    .WithPath("/api/public/v1/research/products/productCode/sales-history/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.SalesHistoryAsync(
            new SalesHistoryProductsRequest { ProductCode = "productCode" }
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
                      "sales": 706,
                      "revenue": 16898.65,
                      "price": 24.040747591633593
                    },
                    "BE": {
                      "sales": 389,
                      "revenue": 10037.4,
                      "price": 23.991675355291
                    }
                  }
                },
                {
                  "date": "2026-09-01",
                  "markets": {
                    "NL": {
                      "sales": 265,
                      "revenue": 6069.489999999999,
                      "price": 22.517142857142854
                    },
                    "BE": {
                      "sales": 669,
                      "revenue": 15270.669999999998,
                      "price": 22.519642857142856
                    }
                  }
                },
                {
                  "date": "2026-10-01",
                  "markets": {
                    "NL": {
                      "sales": 114,
                      "revenue": 2616.299999999999,
                      "price": 22.950000000000003
                    },
                    "BE": {
                      "sales": 35,
                      "revenue": 803.2500000000001,
                      "price": 22.95
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
                    .WithPath("/api/public/v1/research/products/9300000138905032/sales-history/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.SalesHistoryAsync(
            new SalesHistoryProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
