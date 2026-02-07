using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.UsersContext.Sellers;

public interface ISellerRepository : IRepository<Seller>
{
    Task<Seller?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<bool> IsStoreNameUniqueAsync(string storeName, CancellationToken cancellationToken = default);
}