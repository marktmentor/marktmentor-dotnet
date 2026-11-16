using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "market",
              "period": "period",
              "data": {
                "nicheId": "nicheId",
                "name": "name",
                "productCount": 1,
                "qualityScore": 1.1,
                "competitionScore": 1.1,
                "markets": {
                  "NL": {
                    "searchVolume": 1.1,
                    "sales": 1.1,
                    "revenue": 1.1
                  },
                  "BE": {
                    "searchVolume": 1.1,
                    "sales": 1.1,
                    "revenue": 1.1
                  }
                },
                "periods": [
                  {
                    "period": "period",
                    "markets": {
                      "NL": {
                        "searchVolume": 1.1,
                        "sales": 1.1,
                        "revenue": 1.1
                      },
                      "BE": {
                        "searchVolume": 1.1,
                        "sales": 1.1,
                        "revenue": 1.1
                      }
                    }
                  },
                  {
                    "period": "period",
                    "markets": {
                      "NL": {
                        "searchVolume": 1.1,
                        "sales": 1.1,
                        "revenue": 1.1
                      },
                      "BE": {
                        "searchVolume": 1.1,
                        "sales": 1.1,
                        "revenue": 1.1
                      }
                    }
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.GetAsync(new GetNichesRequest { NicheId = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "market": "ALL",
              "period": "30d",
              "data": {
                "nicheId": "6797",
                "name": "drinkfles",
                "productCount": 25956,
                "qualityScore": 5.83,
                "competitionScore": 10,
                "markets": {
                  "NL": {
                    "searchVolume": 6286,
                    "sales": 32892,
                    "revenue": 728137.05
                  },
                  "BE": {
                    "searchVolume": 2332,
                    "sales": 7810,
                    "revenue": 177062.22
                  }
                },
                "periods": [
                  {
                    "period": "30d",
                    "markets": {
                      "NL": {
                        "searchVolume": 6286,
                        "sales": 32892,
                        "revenue": 728137.05
                      },
                      "BE": {
                        "searchVolume": 2332,
                        "sales": 7810,
                        "revenue": 177062.22
                      }
                    }
                  },
                  {
                    "period": "90d",
                    "markets": {
                      "NL": {
                        "searchVolume": 24608,
                        "sales": 109683,
                        "revenue": 2448182.42
                      },
                      "BE": {
                        "searchVolume": 11883,
                        "sales": 30952,
                        "revenue": 735380.25
                      }
                    }
                  },
                  {
                    "period": "365d",
                    "markets": {
                      "NL": {
                        "searchVolume": 96121,
                        "sales": 396331,
                        "revenue": 8464198.77
                      },
                      "BE": {
                        "searchVolume": 40019,
                        "sales": 103561,
                        "revenue": 2367444.83
                      }
                    }
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Niches.GetAsync(new GetNichesRequest { NicheId = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
