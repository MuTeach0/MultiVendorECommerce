using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Tiers;

public interface IQuantityTierRepository : IRepository<PricingQuantityTier>
{
    Task<IEnumerable<PricingQuantityTier>> GetTiersByOfferIdAsync(Guid offerId, CancellationToken cancellationToken = default);
}