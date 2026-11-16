using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReviewSummaryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "data": {
                "averageRating": 1.1,
                "reviewCount": 1,
                "ratings": [
                  {
                    "rating": 1,
                    "count": 1
                  },
                  {
                    "rating": 1,
                    "count": 1
                  }
                ],
                "positiveTopics": [
                  {
                    "topic": "topic",
                    "count": 1
                  },
                  {
                    "topic": "topic",
                    "count": 1
                  }
                ],
                "negativeTopics": [
                  {
                    "topic": "topic",
                    "count": 1
                  },
                  {
                    "topic": "topic",
                    "count": 1
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/productCode/reviews/summary/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.ReviewSummaryAsync(
            new ReviewSummaryProductsRequest { ProductCode = "productCode" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "data": {
                "averageRating": 4.253521126760563,
                "reviewCount": 71,
                "ratings": [
                  {
                    "rating": 5,
                    "count": 50
                  },
                  {
                    "rating": 4,
                    "count": 6
                  },
                  {
                    "rating": 3,
                    "count": 4
                  },
                  {
                    "rating": 2,
                    "count": 5
                  },
                  {
                    "rating": 1,
                    "count": 6
                  }
                ],
                "positiveTopics": [
                  {
                    "topic": "Handig in gebruik",
                    "count": 37
                  },
                  {
                    "topic": "Goede kwaliteit",
                    "count": 34
                  },
                  {
                    "topic": "Voldoet aan verwachting",
                    "count": 23
                  }
                ],
                "negativeTopics": [
                  {
                    "topic": "Slechte kwaliteit",
                    "count": 7
                  },
                  {
                    "topic": "Voldoet niet aan verwachting",
                    "count": 4
                  },
                  {
                    "topic": "geen",
                    "count": 2
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/reviews/summary/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.ReviewSummaryAsync(
            new ReviewSummaryProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
