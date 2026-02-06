using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.Users;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}