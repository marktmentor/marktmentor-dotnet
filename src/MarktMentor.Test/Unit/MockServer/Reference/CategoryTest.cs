using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Reference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CategoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": {
                "categoryId": 1,
                "name": "name",
                "level": 1,
                "parentId": 1,
                "path": [
                  {
                    "categoryId": 1,
                    "name": "name"
                  },
                  {
                    "categoryId": 1,
                    "name": "name"
                  }
                ],
                "childCount": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/reference/categories/1/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Reference.CategoryAsync(
            new CategoryReferenceRequest { CategoryId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": {
                "categoryId": 40142,
                "name": "Drinkflessen",
                "level": 3,
                "parentId": 21822,
                "path": [
                  {
                    "categoryId": 11764,
                    "name": "Koken & Tafelen"
                  },
                  {
                    "categoryId": 21822,
                    "name": "Waterfilters & Drinkflessen"
                  },
                  {
                    "categoryId": 40142,
                    "name": "Drinkflessen"
                  }
                ],
                "childCount": 0
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/reference/categories/1/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Reference.CategoryAsync(
            new CategoryReferenceRequest { CategoryId = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
