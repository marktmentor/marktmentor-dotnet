using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Reference;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CategoriesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "pagination": {
                "page": 1,
                "pageSize": 1,
                "total": 1,
                "hasNext": true
              },
              "data": [
                {
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
                },
                {
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/reference/categories/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Reference.CategoriesAsync(new CategoriesReferenceRequest());
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
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 3,
                "hasNext": false
              },
              "data": [
                {
                  "categoryId": 11764,
                  "name": "Koken & Tafelen",
                  "level": 1,
                  "path": [
                    {
                      "categoryId": 11764,
                      "name": "Koken & Tafelen"
                    }
                  ],
                  "childCount": 16
                },
                {
                  "categoryId": 21822,
                  "name": "Waterfilters & Drinkflessen",
                  "level": 2,
                  "parentId": 11764,
                  "path": [
                    {
                      "categoryId": 11764,
                      "name": "Koken & Tafelen"
                    },
                    {
                      "categoryId": 21822,
                      "name": "Waterfilters & Drinkflessen"
                    }
                  ],
                  "childCount": 5
                },
                {
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/reference/categories/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Reference.CategoriesAsync(
            new CategoriesReferenceRequest { Search = "drinkfles" }
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
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 0,
                "hasNext": false
              },
              "data": [
                {
                  "categoryId": 1,
                  "name": "name",
                  "level": 1,
                  "parentId": 1,
                  "path": [
                    {
                      "categoryId": 1,
                      "name": "name"
                    }
                  ],
                  "childCount": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/reference/categories/")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Reference.CategoriesAsync(
            new CategoriesReferenceRequest { Search = "drinkfles" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
