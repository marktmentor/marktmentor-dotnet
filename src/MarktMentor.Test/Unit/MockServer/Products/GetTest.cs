using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using MarktMentor.Test.Utils;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "NL",
              "period": "period",
              "data": {
                "productCode": "productCode",
                "ean": "ean",
                "title": "title",
                "brand": "brand",
                "familyName": "familyName",
                "imageUrl": "imageUrl",
                "availableSince": "2023-01-15",
                "rating": 1.1,
                "reviewCount": 1,
                "periodReviews": {
                  "count": 1,
                  "averageRating": 1.1,
                  "ratings": {
                    "1": 1,
                    "2": 1,
                    "3": 1,
                    "4": 1,
                    "5": 1
                  }
                },
                "updatedAt": "updatedAt",
                "categories": [
                  {
                    "categoryId": 1,
                    "name": "name"
                  },
                  {
                    "categoryId": 1,
                    "name": "name"
                  }
                ],
                "mainCategoryPosition": 1.1,
                "dimensions": {
                  "lengthCm": 1.1,
                  "widthCm": 1.1,
                  "heightCm": 1.1,
                  "weightGrams": 1.1,
                  "packageType": "packageType"
                },
                "lvbPossible": true,
                "commission": [
                  {
                    "priceBelow": 1.1,
                    "fixed": 1.1,
                    "percentage": 1.1
                  },
                  {
                    "priceBelow": 1.1,
                    "fixed": 1.1,
                    "percentage": 1.1
                  }
                ],
                "markets": {
                  "NL": {
                    "price": 1.1,
                    "sales": 1.1,
                    "revenue": 1.1,
                    "impressions": 1.1,
                    "sellerCount": 1,
                    "searchTermCount": 1.1,
                    "deliveryDays": 1.1
                  },
                  "BE": {
                    "price": 1.1,
                    "sales": 1.1,
                    "revenue": 1.1,
                    "impressions": 1.1,
                    "sellerCount": 1,
                    "searchTermCount": 1.1,
                    "deliveryDays": 1.1
                  }
                },
                "variantCodes": [
                  "variantCodes",
                  "variantCodes"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/productCode/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.GetAsync(
            new GetProductsRequest { ProductCode = "productCode" }
        );
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
                "productCode": "9300000138905032",
                "ean": "5407005143414",
                "title": "Kambukka Elton drinkfles 750ml - Wild Storm met 3-in-1 deksel en makkelijke reiniging",
                "brand": "Kambukka",
                "familyName": "Elton drinkfles",
                "imageUrl": "https://media.s-bol.com/75rpmjnMAm1G/wm63AjM/550x604.jpg",
                "availableSince": "2023-04-21",
                "rating": 4.2,
                "reviewCount": 70,
                "periodReviews": {
                  "count": 4,
                  "averageRating": 5,
                  "ratings": {
                    "1": 0,
                    "2": 0,
                    "3": 0,
                    "4": 0,
                    "5": 4
                  }
                },
                "updatedAt": "2026-11-12T00:00:00Z",
                "categories": [
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
                "mainCategoryPosition": 3,
                "dimensions": {
                  "lengthCm": 25.899999618530273,
                  "widthCm": 10.399999618530273,
                  "heightCm": 9.399999618530273,
                  "weightGrams": 200,
                  "packageType": "Pakket M"
                },
                "lvbPossible": true,
                "commission": [
                  {
                    "priceBelow": 10,
                    "fixed": 0.3,
                    "percentage": 13
                  },
                  {
                    "priceBelow": 20,
                    "fixed": 0.54,
                    "percentage": 13
                  },
                  {
                    "priceBelow": 100,
                    "fixed": 1.15,
                    "percentage": 13
                  },
                  {
                    "fixed": 1.15,
                    "percentage": 13
                  }
                ],
                "markets": {
                  "NL": {
                    "price": 22.45,
                    "sales": 148,
                    "revenue": 3292.32,
                    "impressions": 2434,
                    "sellerCount": 2,
                    "searchTermCount": 11,
                    "deliveryDays": 1.13
                  },
                  "BE": {
                    "price": 22.45,
                    "sales": 45,
                    "revenue": 1000.55,
                    "impressions": 1972,
                    "sellerCount": 2,
                    "searchTermCount": 11,
                    "deliveryDays": 1.13
                  }
                },
                "variantCodes": [
                  "9300000022650450",
                  "9300000138905029",
                  "9300000138905030"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/products/9300000138905032/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Products.GetAsync(
            new GetProductsRequest { ProductCode = "9300000138905032" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
