using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Audit;
public interface IPriceAuditRepository
{
    Task AddAsync(PriceAuditLog log, CancellationToken cancellationToken = default);
    Task<IEnumerable<PriceAuditLog>> GetHistoryByOfferIdAsync(Guid offerId);
}