using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Usage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "organization": {
                "id": 1,
                "name": "name"
              },
              "credential": "oauth",
              "plan": "bundle",
              "bundle": {
                "includedRequests": 1,
                "usedRequests": 1,
                "remainingRequests": 1,
                "additionalRequests": 1,
                "additionalRequestsLimitAmount": 1,
                "periodStart": "2024-01-15T09:30:00.000Z",
                "periodEnd": "2024-01-15T09:30:00.000Z"
              },
              "freeTier": {
                "eligible": true,
                "limit": 1,
                "used": 1,
                "remaining": 1,
                "pageSize": 1,
                "resetsAt": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/usage/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Usage.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "organization": {
                "id": 42,
                "name": "Voorbeeldwinkel BV"
              },
              "credential": "oauth",
              "plan": "bundle",
              "bundle": {
                "includedRequests": 1000,
                "usedRequests": 312,
                "remainingRequests": 688,
                "additionalRequests": 0,
                "additionalRequestsLimitAmount": 0,
                "periodStart": "2026-09-12T08:00:00.000Z",
                "periodEnd": "2026-10-12T08:00:00.000Z"
              },
              "freeTier": {
                "eligible": true,
                "limit": 100,
                "used": 0,
                "remaining": 100,
                "pageSize": 10,
                "resetsAt": "2026-10-01T00:00:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/usage/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Usage.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
