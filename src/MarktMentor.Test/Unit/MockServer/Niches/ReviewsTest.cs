using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

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
                    .WithPath("/api/public/v1/research/niches/1/reviews/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ReviewsAsync(new ReviewsNichesRequest { NicheId = 1 });
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
                  "reviewId": "b30e6f27d7759ad3412984dcd6364f44",
                  "productCode": "9300000004642525",
                  "rating": 5,
                  "text": "Isoleert goed. Dop sluit erg goed en gemakkelijk af (niet te vast draaien, is niet nodig). Een koffiefilter past goed op de fles maar door de smalle diameter valt hij vrij makkelijk eraf. Voorzichtig dus.",
                  "date": "2026-11-11T00:00:00",
                  "verifiedPurchase": true,
                  "helpfulVotes": 0
                },
                {
                  "reviewId": "58c9693124253c517a47891c9f8a68f9",
                  "productCode": "9300000042381335",
                  "rating": 5,
                  "text": "ideaal houd warm en koud",
                  "date": "2026-11-11T00:00:00",
                  "verifiedPurchase": true,
                  "helpfulVotes": 0
                },
                {
                  "reviewId": "e71cc80f8f73050b9457980c2f2088b2",
                  "productCode": "9300000227089632",
                  "rating": 5,
                  "text": "Fijne drinkfles en ook fijn dat ie in de vaatwasser kan, lekt niet.",
                  "date": "2026-11-11T00:00:00",
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
                    .WithPath("/api/public/v1/research/niches/1/reviews/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ReviewsAsync(
            new ReviewsNichesRequest { NicheId = 1, Search = "drinkfles" }
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
                    .WithPath("/api/public/v1/research/niches/1/reviews/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ReviewsAsync(
            new ReviewsNichesRequest { NicheId = 1, Search = "drinkfles" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
