
namespace MultiVendor.Domain.Entities.MarketplaceContext.Inventory;

public interface IInventoryRepository
{
    Task AddAsync(InventoryLog log, CancellationToken cancellationToken = default);
    Task<IEnumerable<InventoryLog>> GetLogsByOfferIdAsync(Guid offerId);
}