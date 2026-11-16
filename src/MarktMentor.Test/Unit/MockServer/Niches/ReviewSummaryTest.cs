using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

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
                    .WithPath("/api/public/v1/research/niches/1/reviews/summary/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ReviewSummaryAsync(
            new ReviewSummaryNichesRequest { NicheId = 1 }
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
                "averageRating": 4.32129611555729,
                "reviewCount": 10246,
                "ratings": [
                  {
                    "rating": 5,
                    "count": 7231
                  },
                  {
                    "rating": 4,
                    "count": 1207
                  },
                  {
                    "rating": 3,
                    "count": 529
                  },
                  {
                    "rating": 2,
                    "count": 427
                  },
                  {
                    "rating": 1,
                    "count": 852
                  }
                ],
                "positiveTopics": [
                  {
                    "topic": "Goede kwaliteit",
                    "count": 5861
                  },
                  {
                    "topic": "Handig in gebruik",
                    "count": 5488
                  },
                  {
                    "topic": "Voldoet aan verwachting",
                    "count": 5034
                  }
                ],
                "negativeTopics": [
                  {
                    "topic": "Voldoet niet aan verwachting",
                    "count": 805
                  },
                  {
                    "topic": "Slechte kwaliteit",
                    "count": 492
                  },
                  {
                    "topic": "Niet gebruiksvriendelijk",
                    "count": 257
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/reviews/summary/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.ReviewSummaryAsync(
            new ReviewSummaryNichesRequest { NicheId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
