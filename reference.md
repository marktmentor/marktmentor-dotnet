# Reference
## Products
<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">ListAsync</a>(ListProductsRequest { ... }) -> Pager&lt;ProductItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search bol products by text, EAN, brand or category, with filters on sales, revenue, price and rating. Each result has the product data and the metrics per market for the chosen period.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.ListAsync(
    new ListProductsRequest
    {
        Brand = "Kambukka",
        Ean = "5407005143414",
        Search = "drinkfles",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">GetAsync</a>(GetProductsRequest { ... }) -> WithRawResponseTask&lt;ProductDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get one product by its bol product code, with the metrics per market for the chosen period, its dimensions, commission and the codes of its variants.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.GetAsync(new GetProductsRequest { ProductCode = "9300000138905032" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">SalesHistoryAsync</a>(SalesHistoryProductsRequest { ... }) -> WithRawResponseTask&lt;SalesHistoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the sales figures of a product over time, per market, in calendar buckets of the chosen interval.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.SalesHistoryAsync(
    new SalesHistoryProductsRequest { ProductCode = "9300000138905032" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SalesHistoryProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">VisibilityHistoryAsync</a>(VisibilityHistoryProductsRequest { ... }) -> WithRawResponseTask&lt;VisibilityHistoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the search visibility of a product over time, per market, in calendar buckets of the chosen interval.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.VisibilityHistoryAsync(
    new VisibilityHistoryProductsRequest { ProductCode = "9300000138905032" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VisibilityHistoryProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">CategoryRankingsAsync</a>(CategoryRankingsProductsRequest { ... }) -> WithRawResponseTask&lt;CategoryRankingsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the positions of a product in its bol categories over time.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.CategoryRankingsAsync(
    new CategoryRankingsProductsRequest { ProductCode = "9300000138905032" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CategoryRankingsProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">KeywordRankingsAsync</a>(KeywordRankingsProductsRequest { ... }) -> WithRawResponseTask&lt;KeywordRankingsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the positions of a product in the bol search results over time, per keyword and market. Name up to 25 keywords with keywordIds (the keywordId values of the keywords endpoint), or get the 10 keywords with the highest search volume.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.KeywordRankingsAsync(
    new KeywordRankingsProductsRequest
    {
        ProductCode = "9300000138905032",
        KeywordIds = "6797,6800,5150",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KeywordRankingsProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">KeywordsAsync</a>(KeywordsProductsRequest { ... }) -> Pager&lt;KeywordItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the search terms a product ranked for in the period, with the figures per market.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.KeywordsAsync(
    new KeywordsProductsRequest { ProductCode = "9300000138905032" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `KeywordsProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">SellersAsync</a>(SellersProductsRequest { ... }) -> WithRawResponseTask&lt;SellerResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the sellers that offered a product in the period, with the figures per market, a buy box summary and the changes to the listing.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.SellersAsync(new SellersProductsRequest { ProductCode = "9300000138905032" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SellersProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">ReviewsAsync</a>(ReviewsProductsRequest { ... }) -> Pager&lt;ReviewItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the reviews of a product, with rating, text and date. Filter on score, verified purchase and text. By default the list has the reviews of the whole product family, as bol shows them on the product page; includeVariants=false gives only the reviews written for this product.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.ReviewsAsync(
    new ReviewsProductsRequest { ProductCode = "9300000138905032", Search = "drinkfles" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReviewsProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Products.<a href="/src/MarktMentor/Products/ProductsClient.cs">ReviewSummaryAsync</a>(ReviewSummaryProductsRequest { ... }) -> WithRawResponseTask&lt;ReviewSummaryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the review totals of a product: the number of reviews, the average rating, the count per star rating and the most named positive and negative topics. By default over the whole product family; includeVariants=false gives only the reviews written for this product.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Products.ReviewSummaryAsync(
    new ReviewSummaryProductsRequest { ProductCode = "9300000138905032" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReviewSummaryProductsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Niches
<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ListAsync</a>(ListNichesRequest { ... }) -> Pager&lt;NicheItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search niches by text or category. A niche is a group of products that serve the same customer need. Each result has the metrics per market for the chosen period.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ListAsync(new ListNichesRequest { Search = "drinkfles" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">GetAsync</a>(GetNichesRequest { ... }) -> WithRawResponseTask&lt;NicheDetailResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get one niche with its quality score, competition score and the metrics per market for the chosen period. With comparePeriods the response also has the core metrics for 30, 90 and 365 days.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.GetAsync(new GetNichesRequest { NicheId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ReviewHistoryAsync</a>(ReviewHistoryNichesRequest { ... }) -> WithRawResponseTask&lt;NicheHistoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the number of reviews and the average rating of the products in a niche over time.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ReviewHistoryAsync(new ReviewHistoryNichesRequest { NicheId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReviewHistoryNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ReviewSummaryAsync</a>(ReviewSummaryNichesRequest { ... }) -> WithRawResponseTask&lt;ReviewSummaryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the review totals of the products in a niche: the number of reviews, the average rating, the count per star rating and the most named positive and negative topics.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ReviewSummaryAsync(new ReviewSummaryNichesRequest { NicheId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReviewSummaryNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ProductDistributionsAsync</a>(ProductDistributionsNichesRequest { ... }) -> WithRawResponseTask&lt;NicheDistributionsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get how the products of a niche are spread over price, sales and revenue, for both markets together.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ProductDistributionsAsync(
    new ProductDistributionsNichesRequest { NicheId = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ProductDistributionsNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ProductsAsync</a>(ProductsNichesRequest { ... }) -> Pager&lt;ProductItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the products in a niche, with the same filters and the same product data as Search products.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ProductsAsync(
    new ProductsNichesRequest
    {
        NicheId = 1,
        Brand = "Kambukka",
        Ean = "5407005143414",
        Search = "drinkfles",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ProductsNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Niches.<a href="/src/MarktMentor/Niches/NichesClient.cs">ReviewsAsync</a>(ReviewsNichesRequest { ... }) -> Pager&lt;ReviewItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the reviews of the products in a niche. Filter on score, verified purchase and text.

A successful request counts as one research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Niches.ReviewsAsync(new ReviewsNichesRequest { NicheId = 1, Search = "drinkfles" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReviewsNichesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Reference
<details><summary><code>client.Reference.<a href="/src/MarktMentor/Reference/ReferenceClient.cs">CategoriesAsync</a>(CategoriesReferenceRequest { ... }) -> Pager&lt;Category&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The bol category tree. Use it to find the `categoryId` for the product, niche and store filters. Send `level=1` for the top of the tree, `parentId` for the categories below one category, or `search` to find a category by name. Without a filter you get all categories, in the order of the tree.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Reference.CategoriesAsync(new CategoriesReferenceRequest { Search = "drinkfles" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CategoriesReferenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Reference.<a href="/src/MarktMentor/Reference/ReferenceClient.cs">CategoryAsync</a>(CategoryReferenceRequest { ... }) -> WithRawResponseTask&lt;CategoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

One category with its level, its parent and its path. Use it to show the name and the path of a `categoryId` that you already have.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Reference.CategoryAsync(new CategoryReferenceRequest { CategoryId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CategoryReferenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Reference.<a href="/src/MarktMentor/Reference/ReferenceClient.cs">BrandsAsync</a>(BrandsReferenceRequest { ... }) -> WithRawResponseTask&lt;BrandListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Brand names that hold your search text, the brand with the most products first. The `brand` filter of a product search needs the exact name: copy it from this response.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Reference.BrandsAsync(new BrandsReferenceRequest { Search = "philips" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BrandsReferenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organization
<details><summary><code>client.Organization.<a href="/src/MarktMentor/Organization/OrganizationClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;Organization&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the organization that the credential belongs to. Use it to check which organization an API key or a portal connection reads.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organization.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Usage
<details><summary><code>client.Usage.<a href="/src/MarktMentor/Usage/UsageClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;Usage&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the research requests of the organization in the current period: what the API bundle includes, what is used and what is left, or the state of the free monthly allowance. Use it to stop before the limit.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Usage.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Store
<details><summary><code>client.Store.<a href="/src/MarktMentor/Store/StoreClient.cs">OverviewAsync</a>(OverviewStoreRequest { ... }) -> WithRawResponseTask&lt;StoreOverviewResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the revenue, costs, profit, orders, sales and returns of your own connected bol store for a period, compared with the period before.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Store.OverviewAsync(new OverviewStoreRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `OverviewStoreRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Store.<a href="/src/MarktMentor/Store/StoreClient.cs">ProductsAsync</a>(ProductsStoreRequest { ... }) -> Pager&lt;StorePerformanceProductPerformanceItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the products of your own connected bol store that had orders in the period, with sales, revenue, costs and profit per product.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Store.ProductsAsync(new ProductsStoreRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ProductsStoreRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Store.<a href="/src/MarktMentor/Store/StoreClient.cs">InventoryAsync</a>(InventoryStoreRequest { ... }) -> Pager&lt;StoreInventoryRow&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List the active products of your own connected bol store with their stock and stock state.

This request is free: it does not count as a research request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Store.InventoryAsync(new InventoryStoreRequest { Ean = "5407005143414" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InventoryStoreRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

