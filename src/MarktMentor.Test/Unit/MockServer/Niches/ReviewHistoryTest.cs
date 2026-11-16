using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReviewHistoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "period": "period",
              "interval": "interval",
              "data": {
                "reviews": [
                  {
                    "date": "2023-01-15",
                    "reviewCount": 1,
                    "averageRating": 1.1
                  },
                  {
                    "date": "2023-01-15",
                    "reviewCount": 1,
                    "averageRating": 1.1
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/review-history/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ReviewHistoryAsync(
            new ReviewHistoryNichesRequest { NicheId = 1 }
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
              "data": {
                "reviews": [
                  {
                    "date": "2026-08-01",
                    "reviewCount": 318,
                    "averageRating": 4.30188679245283
                  },
                  {
                    "date": "2026-09-01",
                    "reviewCount": 248,
                    "averageRating": 4.056451612903226
                  },
                  {
                    "date": "2026-10-01",
                    "reviewCount": 257,
                    "averageRating": 4.311284046692607
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/review-history/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ReviewHistoryAsync(
            new ReviewHistoryNichesRequest { NicheId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
