using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.UsersContext.Users;

namespace MultiVendor.Domain.Entities.UsersContext.Customers;

public sealed class CustomerAddress : AuditableEntity
{
    public Guid CustomerId { get; private set; }
    public string AddressDetails { get; private set; } = string.Empty;
    public bool IsDefault { get; private set; }

    private CustomerAddress() { }

    private CustomerAddress(Guid id, Guid customerId, string addressDetails, bool isDefault) 
        : base(id)
    {
        CustomerId = customerId;
        AddressDetails = addressDetails;
        IsDefault = isDefault;
    }

    public static Result<CustomerAddress> Create(Guid customerId, string addressDetails, bool isDefault = false)
    {
        if (string.IsNullOrWhiteSpace(addressDetails))
            return UserErrors.EmptyAddress;

        return new CustomerAddress(Guid.NewGuid(), customerId, addressDetails, isDefault);
    }

    public void SetAsDefault() => IsDefault = true;
    public void UnsetAsDefault() => IsDefault = false;
    
    public void UpdateAddress(string newDetails)
    {
        if (!string.IsNullOrWhiteSpace(newDetails))
            AddressDetails = newDetails;
    }
}