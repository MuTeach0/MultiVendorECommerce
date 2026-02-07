using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Audit;
using MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Tiers;
using MultiVendor.Domain.Entities.MarketplaceContext.Pricing.Variations;
using MultiVendor.Domain.Entities.UsersContext.Sellers;

namespace MultiVendor.Domain.Entities.MarketplaceContext.Offers;

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

    // داخل SellerOffer.cs
    private readonly List<PricingVariation> _variations = new();
    public IReadOnlyCollection<PricingVariation> Variations => _variations.AsReadOnly();

    private readonly List<PricingQuantityTier> _tiers = new();
    public IReadOnlyCollection<PricingQuantityTier> Tiers => _tiers.AsReadOnly();

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

    // --- Price Guard Implementation ---
    public Result UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) return SellerErrors.InvalidPrice;

        // حساب نسبة التغيير (Safety Guard)
        decimal changePercentage = Math.Abs((newPrice - BasePrice) / BasePrice);
        if (changePercentage > 0.50m)
        {
            return PriceAuditLogErrors.AbnormalChange;
        }

        BasePrice = newPrice;
        // هنا ممكن نضيف Domain Event مستقبلاً للـ Audit Log
        return Result.Success();
    }

    // --- Inventory Management ---
    public void UpdateStock(int newQuantity)
    {
        if (newQuantity >= 0) StockQuantity = newQuantity;
    }

    // --- BuyBox Management ---
    public void SetBuyBoxWinner(bool isWinner, decimal score)
    {
        IsBuyBoxWinner = isWinner;
        BuyBoxScore = score;
        BuyBoxUpdatedAt = DateTime.UtcNow;
    }

    // --- Aggregate Root Methods (لحماية التناسق) ---
    public void AddVariation(PricingVariation variation)
    {
        // ممكن تضيف logic للتأكد إن الـ SKU مش متكرر هنا برضه
        _variations.Add(variation);
    }

    public void AddQuantityTier(PricingQuantityTier tier)
    {
        // منطق لمنع تداخل الكميات (Overlapping)
        if (!_tiers.Any(t => t.MinQuantity == tier.MinQuantity))
        {
            _tiers.Add(tier);
        }
    }
}