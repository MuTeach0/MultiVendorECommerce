using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Variations;

public static class PricingVariationErrors
{
    public static Error EmptySku => Error.Validation("Variation.EmptySku", "SKU Variant cannot be empty.");
    public static Error EmptyAttributes => Error.Validation("Variation.EmptyAttributes", "Attributes (JSON) cannot be empty.");
    public static Error InvalidPriceAdjustment => Error.Validation("Variation.InvalidPrice", "Price adjustment is out of allowed range.");
    public static Error NotFound => Error.NotFound("Variation.NotFound", "The pricing variation was not found.");
    public static Error DuplicateSku => Error.Conflict("Variation.DuplicateSku", "This SKU Variant already exists for this offer.");
}