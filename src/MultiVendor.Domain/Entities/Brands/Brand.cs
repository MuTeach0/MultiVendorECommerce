using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Constants;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Brands;
public sealed class Brand : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    private Brand() { }

    private Brand(Guid id, string name, bool isActive) : base(id)
    {
        Name = name;
        IsActive = isActive;
    }

    public static Result<Brand> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BrandErrors.EmptyName;

        if (name.Length > ValidationConstants.MaxNameLength)
            return GeneralErrors.InputTooLong(nameof(Name), ValidationConstants.MaxNameLength);

        return new Brand(Guid.NewGuid(), name, true);
    }

    public Result Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BrandErrors.EmptyName;

        Name = name;
        return Result.Success();
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}