using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Store;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ProductsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "period": {
                "startDate": "2023-01-15",
                "endDate": "2023-01-15",
                "days": 1
              },
              "filters": {
                "country": "country",
                "eans": [
                  "eans",
                  "eans"
                ],
                "categoryId": 1
              },
              "data": [
                {
                  "title": "title",
                  "ean": "ean",
                  "inSelectedStore": true,
                  "image": "image",
                  "reviewScore": 1.1,
                  "reviewCount": 1,
                  "productLink": "productLink",
                  "productCode": "productCode",
                  "sales": 1.1,
                  "orders": 1.1,
                  "revenue": 1.1,
                  "netRevenue": 1.1,
                  "commission": 1.1,
                  "totalCosts": 1.1,
                  "salesCosts": 1.1,
                  "salesCostsBreakdown": {
                    "shippingCosts": 1.1,
                    "surcharge": 1.1,
                    "productCosts": 1.1,
                    "surchargeRefunds": 1.1,
                    "shippingLabelRefunds": 1.1,
                    "commission": 1.1,
                    "commissionCorrection": 1.1,
                    "compensation": 1.1
                  },
                  "salesProfits": 1.1,
                  "salesProfitMargin": 1.1,
                  "salesRoi": 1.1,
                  "returns": 1.1,
                  "returnCosts": 1.1,
                  "returnCostsBreakdown": {
                    "otherReturnCosts": 1.1,
                    "returnLabelCost": 1.1,
                    "productLostLeniency": 1.1,
                    "otherCompensation": 1.1,
                    "commissionCorrection": 1.1,
                    "revenueCorrection": 1.1,
                    "shipAdditionalProducts": 1.1,
                    "productsBackInStockCorrection": 1.1
                  },
                  "totalProfits": 1.1,
                  "totalMargin": 1.1,
                  "totalRoi": 1.1,
                  "clicks": 1.1,
                  "conversion": 1.1,
                  "conversionBenchmark": 1.1,
                  "adCost": 1.1,
                  "acos": 1.1,
                  "tacos": 1.1,
                  "isActive": true,
                  "storageCosts": 1.1,
                  "gradedStorageCosts": 1.1,
                  "hasProductCosts": true
                },
                {
                  "title": "title",
                  "ean": "ean",
                  "inSelectedStore": true,
                  "image": "image",
                  "reviewScore": 1.1,
                  "reviewCount": 1,
                  "productLink": "productLink",
                  "productCode": "productCode",
                  "sales": 1.1,
                  "orders": 1.1,
                  "revenue": 1.1,
                  "netRevenue": 1.1,
                  "commission": 1.1,
                  "totalCosts": 1.1,
                  "salesCosts": 1.1,
                  "salesCostsBreakdown": {
                    "shippingCosts": 1.1,
                    "surcharge": 1.1,
                    "productCosts": 1.1,
                    "surchargeRefunds": 1.1,
                    "shippingLabelRefunds": 1.1,
                    "commission": 1.1,
                    "commissionCorrection": 1.1,
                    "compensation": 1.1
                  },
                  "salesProfits": 1.1,
                  "salesProfitMargin": 1.1,
                  "salesRoi": 1.1,
                  "returns": 1.1,
                  "returnCosts": 1.1,
                  "returnCostsBreakdown": {
                    "otherReturnCosts": 1.1,
                    "returnLabelCost": 1.1,
                    "productLostLeniency": 1.1,
                    "otherCompensation": 1.1,
                    "commissionCorrection": 1.1,
                    "revenueCorrection": 1.1,
                    "shipAdditionalProducts": 1.1,
                    "productsBackInStockCorrection": 1.1
                  },
                  "totalProfits": 1.1,
                  "totalMargin": 1.1,
                  "totalRoi": 1.1,
                  "clicks": 1.1,
                  "conversion": 1.1,
                  "conversionBenchmark": 1.1,
                  "adCost": 1.1,
                  "acos": 1.1,
                  "tacos": 1.1,
                  "isActive": true,
                  "storageCosts": 1.1,
                  "gradedStorageCosts": 1.1,
                  "hasProductCosts": true
                }
              ],
              "pagination": {
                "page": 1,
                "pageSize": 1,
                "total": 1,
                "hasNext": true,
                "totalMayBeCapped": true
              },
              "costsVisible": true,
              "asOf": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/products/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Store.ProductsAsync(new ProductsStoreRequest());
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
              "period": {
                "startDate": "2026-08-23",
                "endDate": "2026-09-21",
                "days": 30
              },
              "filters": {},
              "data": [
                {
                  "title": "Voorbeeld drinkfles 750 ml",
                  "ean": "8712345678906",
                  "inSelectedStore": true,
                  "reviewScore": 4.5,
                  "reviewCount": 120,
                  "productCode": "9300000000001",
                  "sales": 120,
                  "orders": 110,
                  "revenue": 2400,
                  "netRevenue": 2400,
                  "commission": 300,
                  "totalCosts": 1500,
                  "salesCosts": 1350,
                  "salesCostsBreakdown": {
                    "shippingCosts": 250,
                    "surcharge": 0,
                    "productCosts": 800,
                    "surchargeRefunds": 0,
                    "shippingLabelRefunds": 0,
                    "commission": 300,
                    "commissionCorrection": 0,
                    "compensation": 0
                  },
                  "salesProfits": 1050,
                  "salesProfitMargin": 43.75,
                  "salesRoi": 77.78,
                  "returns": 4,
                  "returnCosts": 30,
                  "returnCostsBreakdown": {
                    "otherReturnCosts": 10,
                    "returnLabelCost": 20,
                    "productLostLeniency": 0,
                    "otherCompensation": 0,
                    "commissionCorrection": 0,
                    "revenueCorrection": 0,
                    "shipAdditionalProducts": 0,
                    "productsBackInStockCorrection": 0
                  },
                  "totalProfits": 900,
                  "totalMargin": 37.5,
                  "totalRoi": 60,
                  "clicks": 2200,
                  "conversion": 5,
                  "adCost": 100,
                  "acos": 8.33,
                  "tacos": 4.17,
                  "isActive": true,
                  "storageCosts": 15,
                  "gradedStorageCosts": 5,
                  "hasProductCosts": true
                }
              ],
              "pagination": {
                "page": 1,
                "pageSize": 25,
                "total": 1,
                "hasNext": false,
                "totalMayBeCapped": false
              },
              "costsVisible": true,
              "asOf": "2026-09-22T08:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/store/products/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Store.ProductsAsync(new ProductsStoreRequest());
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
