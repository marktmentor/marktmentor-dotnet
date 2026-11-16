using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Store;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InventoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "filters": {
                "ean": "ean",
                "stockState": "stockState"
              },
              "data": [
                {
                  "ean": "ean",
                  "title": "title",
                  "stock": 1,
                  "stockState": "out_of_stock",
                  "source": "source",
                  "stockLastUpdated": "2024-01-15T09:30:00.000Z",
                  "unknownReason": "unknownReason"
                },
                {
                  "ean": "ean",
                  "title": "title",
                  "stock": 1,
                  "stockState": "out_of_stock",
                  "source": "source",
                  "stockLastUpdated": "2024-01-15T09:30:00.000Z",
                  "unknownReason": "unknownReason"
                }
              ],
              "pagination": {
                "page": 1,
                "pageSize": 1,
                "total": 1,
                "hasNext": true
              },
              "counts": {
                "resolved": 1,
                "outOfStock": 1,
                "low": 1,
                "ok": 1,
                "unknown": 1
              },
              "countsScope": "resolved_page",
              "asOf": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/inventory/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Store.InventoryAsync(new InventoryStoreRequest());
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
              "filters": {},
              "data": [
                {
                  "ean": "8712345678906",
                  "title": "Voorbeeld drinkfles 750 ml",
                  "stock": 42,
                  "stockState": "ok",
                  "source": "fbb_regular",
                  "stockLastUpdated": "2026-09-22T06:30:00.000Z"
                },
                {
                  "ean": "8712345678913",
                  "title": "Voorbeeld drinkfles 500 ml",
                  "stockState": "unknown",
                  "stockLastUpdated": "2026-09-18T06:30:00.000Z",
                  "unknownReason": "stale_stock"
                }
              ],
              "pagination": {
                "page": 1,
                "pageSize": 25,
                "total": 2,
                "hasNext": false
              },
              "counts": {
                "resolved": 2,
                "outOfStock": 0,
                "low": 0,
                "ok": 1,
                "unknown": 1
              },
              "countsScope": "resolved_page",
              "asOf": "2026-09-22T08:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/inventory/")
                    .WithParam("ean", "5407005143414")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Store.InventoryAsync(
            new InventoryStoreRequest { Ean = "5407005143414" }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
