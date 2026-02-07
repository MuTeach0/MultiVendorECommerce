using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.CatalogContext.Products;

public sealed class ProductMedia : AuditableEntity
{
    public Guid ProductId { get; private set; }
    public string Url { get; private set; } = string.Empty;
    public bool IsPrimary { get; private set; }

    // Navigation Property لربط الصورة بالمنتج الأساسي
    public Product Product { get; private set; } = null!;

    private ProductMedia() { }

    private ProductMedia(Guid id, Guid productId, string url, bool isPrimary) 
        : base(id)
    {
        ProductId = productId;
        Url = url;
        IsPrimary = isPrimary;
    }

    public static Result<ProductMedia> Create(Guid productId, string url, bool isPrimary = false)
    {
        if (productId == Guid.Empty)
            return ProductErrors.InvalidProductId;

        if (string.IsNullOrWhiteSpace(url))
            return ProductErrors.EmptyMediaUrl;

        return new ProductMedia(Guid.NewGuid(), productId, url, isPrimary);
    }

    public void MarkAsPrimary() => IsPrimary = true;
    public void UnmarkAsPrimary() => IsPrimary = false;
}