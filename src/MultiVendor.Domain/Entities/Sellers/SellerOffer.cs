using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Sellers;

public sealed class SellerOffer : AuditableEntity, IAggregateRoot
{
    public Guid SellerId { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal BasePrice { get; private set; }
    public int StockQuantity { get; private set; }
    
    // حقول الـ BuyBox حسب الـ Schema
    public decimal BuyBoxScore { get; private set; }
    public bool IsBuyBoxWinner { get; private set; }
    public DateTime? BuyBoxUpdatedAt { get; private set; }

    private SellerOffer() { }

    private SellerOffer(Guid id, Guid sellerId, Guid productId, decimal basePrice, int stockQuantity) 
        : base(id)
    {
        SellerId = sellerId;
        ProductId = productId;
        BasePrice = basePrice;
        StockQuantity = stockQuantity;
        IsBuyBoxWinner = false;
        BuyBoxScore = 0;
    }

    public static Result<SellerOffer> Create(Guid sellerId, Guid productId, decimal basePrice, int stockQuantity)
    {
        if (basePrice <= 0) 
            return SellerErrors.InvalidPrice;
        
        if (stockQuantity < 0) 
            return SellerErrors.InvalidStock;

        return new SellerOffer(Guid.NewGuid(), sellerId, productId, basePrice, stockQuantity);
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice > 0) BasePrice = newPrice;
    }

    public void UpdateStock(int newQuantity)
    {
        if (newQuantity >= 0) StockQuantity = newQuantity;
    }

    public void SetBuyBoxWinner(bool isWinner, decimal score)
    {
        IsBuyBoxWinner = isWinner;
        BuyBoxScore = score;
        BuyBoxUpdatedAt = DateTime.UtcNow;
    }
}