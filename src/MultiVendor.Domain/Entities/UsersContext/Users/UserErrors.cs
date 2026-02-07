using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.UsersContext.Users;

public static class UserErrors
{
    // General User Errors
    public static Error InvalidEmail => Error.Validation("User.InvalidEmail", "The email address is invalid.");
    public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "This email is already registered.");
    public static Error InvalidUserId => Error.Validation("User.InvalidId", "A valid User ID is required.");

    // Customer & Address Errors
    public static Error EmptyFullName => Error.Validation("Customer.EmptyName", "Full name is required.");
    public static Error EmptyAddress => Error.Validation("Address.Empty", "Address details are required.");
}