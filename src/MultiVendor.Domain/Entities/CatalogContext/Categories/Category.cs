using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Constants;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.CatalogContext.Categories;
public sealed class Category : AuditableEntity, IAggregateRoot
{
    public string NameAr { get; private set; } = string.Empty;
    public Guid? ParentId { get; private set; } // Parent Category
    public string? PricingLogicConfig { get; private set; } // JSON Rules for fees
    public bool IsActive { get; private set; }

    private Category() { }

    private Category(Guid id, string nameAr, Guid? parentId, string? pricingConfig) : base(id)
    {
        NameAr = nameAr;
        ParentId = parentId;
        PricingLogicConfig = pricingConfig;
        IsActive = true;
    }

    public static Result<Category> Create(string nameAr, Guid? parentId = null, string? pricingConfig = null)
    {
        if (string.IsNullOrWhiteSpace(nameAr))
            return CategoryErrors.EmptyName;

        if (nameAr.Length > ValidationConstants.MaxNameLength)
            return CategoryErrors.NameTooLong;

        return new Category(Guid.NewGuid(), nameAr, parentId, pricingConfig);
    }

    public Result Update(string nameAr, Guid? parentId, string? pricingConfig)
    {
        if (string.IsNullOrWhiteSpace(nameAr))
            return CategoryErrors.EmptyName;
        
        if (nameAr.Length > ValidationConstants.MaxNameLength)
            return CategoryErrors.NameTooLong;
        NameAr = nameAr;
        ParentId = parentId;
        PricingLogicConfig = pricingConfig;

        return Result.Success();
    }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}