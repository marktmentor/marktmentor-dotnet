using MarktMentor.Core;

namespace MarktMentor;

public partial interface IReferenceClient
{
    /// <summary>
    /// The bol category tree. Use it to find the `categoryId` for the product, niche and store filters. Send `level=1` for the top of the tree, `parentId` for the categories below one category, or `search` to find a category by name. Without a filter you get all categories, in the order of the tree.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    Task<Pager<Category>> CategoriesAsync(
        CategoriesReferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// One category with its level, its parent and its path. Use it to show the name and the path of a `categoryId` that you already have.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    WithRawResponseTask<CategoryResponse> CategoryAsync(
        CategoryReferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Brand names that hold your search text, the brand with the most products first. The `brand` filter of a product search needs the exact name: copy it from this response.
    ///
    /// This request is free: it does not count as a research request.
    /// </summary>
    WithRawResponseTask<BrandListResponse> BrandsAsync(
        BrandsReferenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
