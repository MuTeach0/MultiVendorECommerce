using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Audit;

public sealed class PriceAuditLog : Entity 
{
    public Guid OfferId { get; private set; }
    public decimal OldPrice { get; private set; }
    public decimal NewPrice { get; private set; }
    public string ChangeReason { get; private set; } = string.Empty;
    public Guid ChangedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private PriceAuditLog() { }

    public PriceAuditLog(Guid offerId, decimal oldPrice, decimal newPrice, string reason, Guid userId) 
        : base(Guid.NewGuid())
    {
        OfferId = offerId;
        OldPrice = oldPrice;
        NewPrice = newPrice;
        ChangeReason = reason;
        ChangedBy = userId;
        CreatedAt = DateTime.UtcNow;
    }
}