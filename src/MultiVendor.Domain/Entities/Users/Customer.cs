using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Users;

public sealed class Customer : AuditableEntity, IAggregateRoot
{
    public Guid UserId { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public LoyaltyTier LoyaltyTier { get; private set; }
    public int PointsBalance { get; private set; }

    private Customer() { }

    private Customer(Guid id, Guid userId, string fullName) : base(id)
    {
        UserId = userId;
        FullName = fullName;
        LoyaltyTier = LoyaltyTier.Standard; // يبدأ من أقل فئة
        PointsBalance = 0;
    }

    public static Result<Customer> Create(Guid userId, string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return UserErrors.EmptyFullName;

        return new Customer(Guid.NewGuid(), userId, fullName);
    }

    public void AddPoints(int points)
    {
        if (points > 0) PointsBalance += points;
    }

    public void UpdateTier(LoyaltyTier newTier)
    {
        LoyaltyTier = newTier;
    }
}