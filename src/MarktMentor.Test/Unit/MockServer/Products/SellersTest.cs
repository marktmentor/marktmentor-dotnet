using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SellersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "period": "period",
              "hasMore": true,
              "markets": {
                "NL": {
                  "buyBoxSellerCount": 1,
                  "buyBoxTakeovers": 1,
                  "averageHoursInBuyBox": 1.1
                },
                "BE": {
                  "buyBoxSellerCount": 1,
                  "buyBoxTakeovers": 1,
                  "averageHoursInBuyBox": 1.1
                }
              },
              "listingChanges": {
                "mainImage": 1,
                "title": 1,
                "description": 1
              },
              "data": [
                {
                  "sellerCode": "sellerCode",
                  "name": "name",
                  "rating": 1.1,
                  "markets": {
                    "NL": {
                      "buyBoxShare": 1.1,
                      "averagePrice": 1.1,
                      "deliveryDays": 1.1
                    },
                    "BE": {
                      "buyBoxShare": 1.1,
                      "averagePrice": 1.1,
                      "deliveryDays": 1.1
                    }
                  }
                },
                {
                  "sellerCode": "sellerCode",
                  "name": "name",
                  "rating": 1.1,
                  "markets": {
                    "NL": {
                      "buyBoxShare": 1.1,
                      "averagePrice": 1.1,
                      "deliveryDays": 1.1
                    },
                    "BE": {
                      "buyBoxShare": 1.1,
                      "averagePrice": 1.1,
                      "deliveryDays": 1.1
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
                    .WithPath("/api/public/v1/research/products/productCode/sellers/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.SellersAsync(
            new SellersProductsRequest { ProductCode = "productCode" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "period": "90d",
              "hasMore": false,
              "markets": {
                "NL": {
                  "buyBoxSellerCount": 2,
                  "buyBoxTakeovers": 6,
                  "averageHoursInBuyBox": 139.2
                },
                "BE": {
                  "buyBoxSellerCount": 2,
                  "buyBoxTakeovers": 6,
                  "averageHoursInBuyBox": 139.2
                }
              },
              "listingChanges": {
                "mainImage": 0,
                "title": 0,
                "description": 0
              },
              "data": [
                {
                  "sellerCode": "0",
                  "name": "bol.com",
                  "markets": {
                    "NL": {
                      "buyBoxShare": 87.42100224829716,
                      "averagePrice": 22.540434829385095,
                      "deliveryDays": 1.14
                    },
                    "BE": {
                      "buyBoxShare": 87.91431232705406,
                      "averagePrice": 22.54364821284007,
                      "deliveryDays": 1.14
                    }
                  }
                },
                {
                  "sellerCode": "1049215",
                  "name": "Kambukka",
                  "rating": 9,
                  "markets": {
                    "NL": {
                      "buyBoxShare": 12.578997751702852,
                      "averagePrice": 26.949999999999996,
                      "deliveryDays": 3
                    },
                    "BE": {
                      "buyBoxShare": 12.085687672945934,
                      "averagePrice": 26.949999999999996,
                      "deliveryDays": 3
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
                    .WithPath("/api/public/v1/research/products/9300000138905032/sellers/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.SellersAsync(
            new SellersProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
