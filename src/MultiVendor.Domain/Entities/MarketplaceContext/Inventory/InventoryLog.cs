using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Inventory;

public sealed class InventoryLog : Entity // سجل تاريخي لا يُعدل
{
    public Guid OfferId { get; private set; }
    public int ChangeQty { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private InventoryLog() { }

    public InventoryLog(Guid offerId, int changeQty, string reason) 
        : base(Guid.NewGuid())
    {
        OfferId = offerId;
        ChangeQty = changeQty;
        Reason = reason;
        CreatedAt = DateTime.UtcNow;
    }
}