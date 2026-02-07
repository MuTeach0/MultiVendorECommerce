using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing;

public static class PricingErrors
{
    public static Error InvalidOfferId => Error.Validation("Pricing.InvalidOfferId", "A valid Offer ID is required.");
    public static Error InvalidQuantity => Error.Validation("Pricing.InvalidQuantity", "Minimum quantity must be greater than 1.");
    public static Error InvalidDiscount => Error.Validation("Pricing.InvalidDiscount", "Discount value must be greater than 0.");
    public static Error TierNotFound => Error.NotFound("Pricing.TierNotFound", "The pricing tier was not found.");
    public static Error OverlappingTiers => Error.Conflict("Pricing.OverlappingTiers", "This quantity tier overlaps with an existing one.");
}