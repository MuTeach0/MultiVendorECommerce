using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Variations;

public interface IPricingVariationRepository : IRepository<PricingVariation>
{
    // ميثود لجلب كل التنويعات الخاصة بعرض معين (Offer)
    Task<IEnumerable<PricingVariation>> GetByOfferIdAsync(Guid offerId, CancellationToken cancellationToken = default);
    
    // للتحقق من أن الـ SKU Variant فريد على مستوى العرض
    Task<bool> IsSkuUniqueAsync(Guid offerId, string skuVariant, CancellationToken cancellationToken = default);
}