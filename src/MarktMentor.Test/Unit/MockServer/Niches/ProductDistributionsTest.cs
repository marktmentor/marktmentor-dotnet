using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ProductDistributionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "period": "period",
              "data": {
                "productCount": 1,
                "total": {
                  "price": [
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    },
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    }
                  ],
                  "sales": [
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    },
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    }
                  ],
                  "revenue": [
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    },
                    {
                      "fromValue": 1.1,
                      "toValue": 1.1,
                      "productCount": 1
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/product-distributions/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ProductDistributionsAsync(
            new ProductDistributionsNichesRequest { NicheId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "period": "30d",
              "data": {
                "productCount": 2934,
                "total": {
                  "price": [
                    {
                      "toValue": 11,
                      "productCount": 103
                    },
                    {
                      "fromValue": 11,
                      "toValue": 21,
                      "productCount": 801
                    },
                    {
                      "fromValue": 21,
                      "toValue": 51,
                      "productCount": 1759
                    }
                  ],
                  "sales": [
                    {
                      "toValue": 1,
                      "productCount": 1647
                    },
                    {
                      "fromValue": 1,
                      "toValue": 11,
                      "productCount": 573
                    },
                    {
                      "fromValue": 11,
                      "toValue": 51,
                      "productCount": 469
                    }
                  ],
                  "revenue": [
                    {
                      "toValue": 1,
                      "productCount": 1648
                    },
                    {
                      "fromValue": 1,
                      "toValue": 501,
                      "productCount": 841
                    },
                    {
                      "fromValue": 501,
                      "toValue": 1001,
                      "productCount": 170
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/product-distributions/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ProductDistributionsAsync(
            new ProductDistributionsNichesRequest { NicheId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
