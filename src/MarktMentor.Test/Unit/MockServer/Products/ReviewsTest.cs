using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReviewsTest : BaseMockServerTest
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
                  "reviewId": "reviewId",
                  "productCode": "productCode",
                  "rating": 1,
                  "title": "title",
                  "text": "text",
                  "date": "date",
                  "verifiedPurchase": true,
                  "helpfulVotes": 1
                },
                {
                  "reviewId": "reviewId",
                  "productCode": "productCode",
                  "rating": 1,
                  "title": "title",
                  "text": "text",
                  "date": "date",
                  "verifiedPurchase": true,
                  "helpfulVotes": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/productCode/reviews/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.ReviewsAsync(
            new ReviewsProductsRequest { ProductCode = "productCode" }
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
              "period": "3M",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 3,
                "hasNext": false
              },
              "data": [
                {
                  "reviewId": "8ee5a26102672e9a39159d8aa1643a74",
                  "productCode": "9300000138905030",
                  "rating": 5,
                  "text": "Goeie kwaliteit.  Lekt niet.",
                  "date": "2026-11-08T00:00:00",
                  "verifiedPurchase": true,
                  "helpfulVotes": 0
                },
                {
                  "reviewId": "7f3facf519b4b593b6f4c0611725c09b",
                  "productCode": "9300000022650450",
                  "rating": 5,
                  "text": "Mijn vijfde Kambukka-fles. Echt een aanrader!",
                  "date": "2026-11-06T00:00:00",
                  "verifiedPurchase": true,
                  "helpfulVotes": 0
                },
                {
                  "reviewId": "25334a9aba0a24db6ae20cbb5fe59b99",
                  "productCode": "9300000022650450",
                  "rating": 5,
                  "text": "goede drinkbus",
                  "date": "2026-11-05T00:00:00",
                  "verifiedPurchase": true,
                  "helpfulVotes": 0
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/reviews/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.ReviewsAsync(
            new ReviewsProductsRequest { ProductCode = "9300000138905032", Search = "drinkfles" }
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
              "period": "3M",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 0,
                "hasNext": false
              },
              "data": [
                {
                  "reviewId": "reviewId",
                  "productCode": "productCode",
                  "rating": 1,
                  "title": "title",
                  "text": "text",
                  "date": "date",
                  "verifiedPurchase": true,
                  "helpfulVotes": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/reviews/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Products.ReviewsAsync(
            new ReviewsProductsRequest { ProductCode = "9300000138905032", Search = "drinkfles" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
