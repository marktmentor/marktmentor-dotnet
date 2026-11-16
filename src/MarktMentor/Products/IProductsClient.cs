using MarktMentor.Core;

namespace MarktMentor;

public partial interface IProductsClient
{
    /// <summary>
    /// Search bol products by text, EAN, brand or category, with filters on sales, revenue, price and rating. Each result has the product data and the metrics per market for the chosen period.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<ProductItem>> ListAsync(
        ListProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get one product by its bol product code, with the metrics per market for the chosen period, its dimensions, commission and the codes of its variants.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<ProductDetailResponse> GetAsync(
        GetProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the sales figures of a product over time, per market, in calendar buckets of the chosen interval.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<SalesHistoryResponse> SalesHistoryAsync(
        SalesHistoryProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the search visibility of a product over time, per market, in calendar buckets of the chosen interval.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<VisibilityHistoryResponse> VisibilityHistoryAsync(
        VisibilityHistoryProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the positions of a product in its bol categories over time.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<CategoryRankingsResponse> CategoryRankingsAsync(
        CategoryRankingsProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the positions of a product in the bol search results over time, per keyword and market. Name up to 25 keywords with keywordIds (the keywordId values of the keywords endpoint), or get the 10 keywords with the highest search volume.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<KeywordRankingsResponse> KeywordRankingsAsync(
        KeywordRankingsProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the search terms a product ranked for in the period, with the figures per market.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<KeywordItem>> KeywordsAsync(
        KeywordsProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the sellers that offered a product in the period, with the figures per market, a buy box summary and the changes to the listing.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<SellerResponse> SellersAsync(
        SellersProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the reviews of a product, with rating, text and date. Filter on score, verified purchase and text. By default the list has the reviews of the whole product family, as bol shows them on the product page; includeVariants=false gives only the reviews written for this product.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<ReviewItem>> ReviewsAsync(
        ReviewsProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the review totals of a product: the number of reviews, the average rating, the count per star rating and the most named positive and negative topics. By default over the whole product family; includeVariants=false gives only the reviews written for this product.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<ReviewSummaryResponse> ReviewSummaryAsync(
        ReviewSummaryProductsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
