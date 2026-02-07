using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.UsersContext.Customers;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Customer?> GetWithAddressesAsync(Guid id, CancellationToken cancellationToken = default);
}