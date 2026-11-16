using MarktMentor.Core;

namespace MarktMentor;

public partial interface INichesClient
{
    /// <summary>
    /// Search niches by text or category. A niche is a group of products that serve the same customer need. Each result has the metrics per market for the chosen period.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<NicheItem>> ListAsync(
        ListNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get one niche with its quality score, competition score and the metrics per market for the chosen period. With comparePeriods the response also has the core metrics for 30, 90 and 365 days.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<NicheDetailResponse> GetAsync(
        GetNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the number of reviews and the average rating of the products in a niche over time.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<NicheHistoryResponse> ReviewHistoryAsync(
        ReviewHistoryNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the review totals of the products in a niche: the number of reviews, the average rating, the count per star rating and the most named positive and negative topics.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<ReviewSummaryResponse> ReviewSummaryAsync(
        ReviewSummaryNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get how the products of a niche are spread over price, sales and revenue, for both markets together.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    WithRawResponseTask<NicheDistributionsResponse> ProductDistributionsAsync(
        ProductDistributionsNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the products in a niche, with the same filters and the same product data as Search products.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<ProductItem>> ProductsAsync(
        ProductsNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the reviews of the products in a niche. Filter on score, verified purchase and text.
    ///
    /// A successful request counts as one research request.
    /// </summary>
    Task<Pager<ReviewItem>> ReviewsAsync(
        ReviewsNichesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
