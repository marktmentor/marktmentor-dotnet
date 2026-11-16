using MarktMentor;
using MarktMentor.Test.Unit.MockServer;
using NUnit.Framework;

namespace MarktMentor.Test.Unit.MockServer.Niches;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ProductsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "market": "NL",
              "period": "period",
              "pagination": {
                "page": 1,
                "pageSize": 1,
                "total": 1,
                "hasNext": true
              },
              "data": [
                {
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
                  }
                },
                {
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
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/products/")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ProductsAsync(new ProductsNichesRequest { NicheId = 1 });
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
              "period": "30d",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 3,
                "hasNext": false
              },
              "data": [
                {
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
                  }
                },
                {
                  "productCode": "9300000265715962",
                  "ean": "8721398606163",
                  "title": "Cabau - Bloom Waterfles / Drinkfles - 1 liter - Cherry - Handige drinktuit & unieke maataanduiding - BPA- & Lekvrij - Drinkfles met rietje volwassenen - Drinkfles volwassenen - Cadeau voor haar",
                  "brand": "cabau",
                  "imageUrl": "https://media.s-bol.com/B4XykYM33OGk/ANmxY5O/289x840.jpg",
                  "availableSince": "2026-07-20",
                  "rating": 4,
                  "reviewCount": 156,
                  "periodReviews": {
                    "count": 0,
                    "ratings": {
                      "1": 0,
                      "2": 0,
                      "3": 0,
                      "4": 0,
                      "5": 0
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
                  "mainCategoryPosition": 37.5,
                  "dimensions": {
                    "lengthCm": 9,
                    "widthCm": 9.5,
                    "heightCm": 30,
                    "weightGrams": 300,
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
                      "price": 23.95,
                      "sales": 831,
                      "revenue": 19902.45,
                      "impressions": 7143,
                      "sellerCount": 0,
                      "searchTermCount": 22,
                      "deliveryDays": 2.57
                    },
                    "BE": {
                      "price": 23.95,
                      "sales": 49,
                      "revenue": 1173.55,
                      "impressions": 248,
                      "sellerCount": 0,
                      "searchTermCount": 10,
                      "deliveryDays": 2.57
                    }
                  }
                },
                {
                  "productCode": "9300000033096850",
                  "ean": "8718469123810",
                  "title": "Dopper Original Drinkfles - 450 ml - Cosmic Storm",
                  "brand": "Dopper",
                  "familyName": "Dopper Original",
                  "imageUrl": "https://media.s-bol.com/gM7JEqjYo6A6/XQYVlNl/250x200.jpg",
                  "availableSince": "2022-02-13",
                  "rating": 4.5,
                  "reviewCount": 696,
                  "periodReviews": {
                    "count": 2,
                    "averageRating": 5,
                    "ratings": {
                      "1": 0,
                      "2": 0,
                      "3": 0,
                      "4": 0,
                      "5": 2
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
                  "mainCategoryPosition": 11,
                  "dimensions": {
                    "lengthCm": 23.600000381469727,
                    "widthCm": 6.099999904632568,
                    "heightCm": 5.599999904632568,
                    "weightGrams": 108,
                    "packageType": "Pakket S"
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
                      "price": 14.95,
                      "sales": 687,
                      "revenue": 10270.65,
                      "impressions": 5581,
                      "sellerCount": 1,
                      "searchTermCount": 12,
                      "deliveryDays": 1.16
                    },
                    "BE": {
                      "price": 14.95,
                      "sales": 151,
                      "revenue": 2257.45,
                      "impressions": 2008,
                      "sellerCount": 1,
                      "searchTermCount": 7,
                      "deliveryDays": 1.16
                    }
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/products/")
                    .WithParam("brand", "Kambukka")
                    .WithParam("ean", "5407005143414")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ProductsAsync(
            new ProductsNichesRequest
            {
                NicheId = 1,
                Brand = "Kambukka",
                Ean = "5407005143414",
                Search = "drinkfles",
            }
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
              "period": "30d",
              "pagination": {
                "page": 1,
                "pageSize": 3,
                "total": 0,
                "hasNext": false
              },
              "data": [
                {
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
                    "ratings": {}
                  },
                  "updatedAt": "updatedAt",
                  "categories": [
                    {
                      "categoryId": 1
                    }
                  ],
                  "mainCategoryPosition": 1.1,
                  "dimensions": {},
                  "lvbPossible": true,
                  "commission": [
                    {}
                  ],
                  "markets": {}
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/public/v1/research/niches/1/products/")
                    .WithParam("brand", "Kambukka")
                    .WithParam("ean", "5407005143414")
                    .WithParam("search", "drinkfles")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Niches.ProductsAsync(
            new ProductsNichesRequest
            {
                NicheId = 1,
                Brand = "Kambukka",
                Ean = "5407005143414",
                Search = "drinkfles",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
