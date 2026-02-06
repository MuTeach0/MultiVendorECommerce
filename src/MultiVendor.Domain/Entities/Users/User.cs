using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Users;

public sealed class User : AuditableEntity, IAggregateRoot
{
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    private User() { }

    private User(Guid id, string email, string passwordHash, UserRole role) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
    }

    public static Result<User> Create(string email, string passwordHash, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(email)) 
            return UserErrors.InvalidEmail;
        
        // هنا ممكن نضيف Regex للـ Email Validation لو حبيت

        return new User(Guid.NewGuid(), email, passwordHash, role);
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}