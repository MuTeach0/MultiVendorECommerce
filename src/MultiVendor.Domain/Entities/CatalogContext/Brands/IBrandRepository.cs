using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.CatalogContext.Brands;

public interface IBrandRepository : IRepository<Brand>
{
    Task<bool> IsNameUniqueAsync(
        string name,
        CancellationToken cancellationToken = default);
}