using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.MarketplaceContext.Offers;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Tiers;

public sealed class PricingQuantityTier : AuditableEntity, IAggregateRoot
{
    public Guid OfferId { get; private set; }
    public int MinQuantity { get; private set; }
    public decimal DiscountValue { get; private set; }
    public SellerOffer SellerOffer { get; private set; } = null!;
    private PricingQuantityTier() { }

    private PricingQuantityTier(Guid id, Guid offerId, int minQuantity, decimal discountValue) 
        : base(id)
    {
        OfferId = offerId;
        MinQuantity = minQuantity;
        DiscountValue = discountValue;
    }

    public static Result<PricingQuantityTier> Create(Guid offerId, int minQuantity, decimal discountValue)
    {
        if (offerId == Guid.Empty)
            return PricingErrors.InvalidOfferId;

        if (minQuantity <= 1)
            return PricingErrors.InvalidQuantity;

        if (discountValue <= 0)
            return PricingErrors.InvalidDiscount;

        return new PricingQuantityTier(Guid.NewGuid(), offerId, minQuantity, discountValue);
    }
    public void UpdateTier(int newQuantity, decimal newDiscount)
    {
        if (newQuantity > 1) MinQuantity = newQuantity;
        if (newDiscount > 0) DiscountValue = newDiscount;
    }
}