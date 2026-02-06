using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Users;

public static class UserErrors
{
    public static Error InvalidEmail => Error.Validation("User.InvalidEmail", "The email address is invalid.");
    public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "This email is already registered.");
    public static Error CustomerNotFound => Error.NotFound("Customer.NotFound", "The customer profile was not found.");
    public static Error AddressNotFound => Error.NotFound("Address.NotFound", "The shipping address was not found.");
    public static Error EmptyFullName => Error.Validation("Customer.EmptyName", "Full name is required.");
    public static Error EmptyAddress => Error.Validation("Address.Empty", "Address details are required.");
}