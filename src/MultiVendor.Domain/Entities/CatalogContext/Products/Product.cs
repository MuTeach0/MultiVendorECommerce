using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.CatalogContext.Brands;
using MultiVendor.Domain.Entities.CatalogContext.Categories;

using MultiVendor.Domain.Entities.MarketplaceContext.Offers;

namespace MultiVendor.Domain.Entities.CatalogContext.Products;

public sealed class Product : AuditableEntity, IAggregateRoot
{
    public string TitleAr { get; private set; } = string.Empty;
    public string DescriptionAr { get; private set; } = string.Empty; // الوصف الموحد للمنتج
    public string MasterSku { get; private set; } = string.Empty;
    public PricingType PricingType { get; private set; } // 1=Fixed, 2=Attribute, etc.
    public bool IsActive { get; private set; }

    public Guid CategoryId { get; private set; }
    public Guid BrandId { get; private set; }
    // Navigation Properties
    public Category Category { get; private set; } = null!;
    public Brand Brand { get; private set; } = null!;
    
    // الربط مع الميديا (صور المنتج)
    private readonly List<ProductMedia> _media = new();
    public IReadOnlyCollection<ProductMedia> Media => _media.AsReadOnly();

    // الربط مع العروض (عروض التجار لهذا المنتج)
    private readonly List<SellerOffer> _offers = new();
    public IReadOnlyCollection<SellerOffer> Offers => _offers.AsReadOnly();
    private Product() { }

    private Product(Guid id,
        string titleAr,
        string descriptionAr,
        string masterSku,
        PricingType pricingType,
        Guid categoryId,
        Guid brandId) 
        : base(id)
    {
        TitleAr = titleAr;
        DescriptionAr = descriptionAr;
        MasterSku = masterSku;
        PricingType = pricingType;
        CategoryId = categoryId;
        BrandId = brandId;
        IsActive = true; 
    }

    public static Result<Product> Create(
        string titleAr, 
        string descriptionAr,
        string masterSku, 
        PricingType pricingType, 
        Guid categoryId, 
        Guid brandId)
    {
        if (string.IsNullOrWhiteSpace(titleAr)) return ProductErrors.EmptyName;
        if (string.IsNullOrWhiteSpace(descriptionAr)) return ProductErrors.EmptyDescription;
        if (string.IsNullOrWhiteSpace(masterSku)) return ProductErrors.EmptySku;

        return new Product(Guid.NewGuid(), titleAr, descriptionAr, masterSku, pricingType, categoryId, brandId);
    }

    public Result UpdateDetails(
        string titleAr,
        string descriptionAr,
        PricingType pricingType,
        Guid categoryId,
        Guid brandId)
    {
        if (string.IsNullOrWhiteSpace(titleAr)) return ProductErrors.EmptyName;
        if (string.IsNullOrWhiteSpace(descriptionAr)) return ProductErrors.EmptyDescription;

        TitleAr = titleAr;
        DescriptionAr = descriptionAr;
        PricingType = pricingType;
        CategoryId = categoryId;
        BrandId = brandId;

        return Result.Success();
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}