using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByVendorIdAsync(Guid vendorId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<bool> IsSkuUniqueAsync(string sku, CancellationToken cancellationToken = default); // SKU لو قررت تضيفه لاحقاً
}