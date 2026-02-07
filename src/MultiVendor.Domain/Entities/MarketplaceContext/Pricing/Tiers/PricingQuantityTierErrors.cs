using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Tiers;

public static class PricingQuantityTierErrors
{
    public static Error NegativeDiscount => Error.Validation("Tier.NegativeDiscount", "Discount value cannot be negative.");
    public static Error InvalidMinQuantity => Error.Validation("Tier.InvalidQty", "Minimum quantity must be at least 2.");
}