using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.MarketplaceContext.Offers;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Variations;

public sealed class PricingVariation : AuditableEntity, IAggregateRoot
{
    public Guid OfferId { get; private set; }
    public string SkuVariant { get; private set; } = string.Empty;
    public string Attributes { get; private set; } = string.Empty; // JSON string
    public decimal PriceAdjustment { get; private set; }

    // Navigation property (Lazy loading/Eager loading)
    public SellerOffer SellerOffer { get; private set; } = null!;

    private PricingVariation() { }

    private PricingVariation(Guid id, Guid offerId, string skuVariant, string attributes, decimal priceAdjustment) 
        : base(id)
    {
        OfferId = offerId;
        SkuVariant = skuVariant;
        Attributes = attributes;
        PriceAdjustment = priceAdjustment;
    }

    public static Result<PricingVariation> Create(Guid offerId, string skuVariant, string attributes, decimal priceAdjustment)
    {
        if (offerId == Guid.Empty)
            return PricingVariationErrors.NotFound;

        if (string.IsNullOrWhiteSpace(skuVariant))
            return PricingVariationErrors.EmptySku;

        if (string.IsNullOrWhiteSpace(attributes))
            return PricingVariationErrors.EmptyAttributes;

        if (priceAdjustment < -10000) // Arbitrary lower bound for price adjustment
            return PricingVariationErrors.InvalidPriceAdjustment;

        return new PricingVariation(Guid.NewGuid(), offerId, skuVariant, attributes, priceAdjustment);
    }

    public void UpdatePrice(decimal newAdjustment)
    {
        PriceAdjustment = newAdjustment;
    }
}