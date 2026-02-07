using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Audit;
public static class PriceAuditLogErrors
{
    public static Error PriceMismatch => Error.Validation("PriceAudit.Mismatch", "The new price must be different from the old price.");
    public static Error AbnormalChange => Error.Validation("PriceAudit.AbnormalChange", "Price change exceeds the 50% safety limit.");
    public static Error LogNotFound => Error.NotFound("PriceAudit.NotFound", "The requested price log was not found.");
}