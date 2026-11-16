using MarktMentor.Core;

namespace MarktMentor;

public partial interface IStoreClient
{
    /// <summary>
    /// Get the revenue, costs, profit, orders, sales and returns of your own connected bol store for a period, compared with the period before.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    WithRawResponseTask<StoreOverviewResponse> OverviewAsync(
        OverviewStoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the products of your own connected bol store that had orders in the period, with sales, revenue, costs and profit per product.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    Task<Pager<StorePerformanceProductPerformanceItem>> ProductsAsync(
        ProductsStoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the active products of your own connected bol store with their stock and stock state.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    Task<Pager<StoreInventoryRow>> InventoryAsync(
        InventoryStoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
