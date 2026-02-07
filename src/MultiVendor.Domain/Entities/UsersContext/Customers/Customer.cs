using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.UsersContext.Users;

namespace MultiVendor.Domain.Entities.UsersContext.Customers;
public sealed class Customer : AuditableEntity, IAggregateRoot
{
    #region Properties
    public Guid UserId { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public LoyaltyTier LoyaltyTier { get; private set; }
    public int PointsBalance { get; private set; }

    // Encapsulated collection for Domain Integrity
    private readonly List<CustomerAddress> _addresses = [];
    public IReadOnlyCollection<CustomerAddress> Addresses => _addresses.AsReadOnly();
    #endregion

    #region Constructors
    private Customer() { }

    private Customer(Guid id, Guid userId, string fullName) : base(id)
    {
        UserId = userId;
        FullName = fullName;
        LoyaltyTier = LoyaltyTier.Standard; // Initial tier as per business rules
        PointsBalance = 0;
    }
    #endregion

    #region Factory Methods
    public static Result<Customer> Create(Guid userId, string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return UserErrors.EmptyFullName;

        if (userId == Guid.Empty)
            return UserErrors.InvalidUserId;

        return new Customer(Guid.NewGuid(), userId, fullName);
    }
    #endregion

    #region Loyalty Logic (PRD 5.4)
    public void EarnPoints(decimal orderAmount) 
    {
        // Points calculation logic based on tier multipliers
        decimal multiplier = LoyaltyTier switch
        {
            LoyaltyTier.Standard => 0.1m,  // 10% cashback in points
            LoyaltyTier.Silver => 0.15m,   // 15% cashback
            LoyaltyTier.Gold => 0.2m,      // 20% cashback
            _ => 0.1m
        };

        int earned = (int)(orderAmount * multiplier); 
        if (earned > 0) PointsBalance += earned;
    }

    public Result RedeemPoints(int points)
    {
        if (points <= 0) 
            return Error.Validation("Customer.InvalidPoints", "Points to redeem must be positive.");
            
        if (PointsBalance < points) 
            return Error.Validation("Customer.InsufficientPoints", "Not enough points balance.");
        
        PointsBalance -= points;
        return Result.Success();
    }

    public void AddPoints(int points) // For manual adjustments or promotions
    {
        if (points > 0) PointsBalance += points;
    }

    public void UpdateTier(LoyaltyTier newTier)
    {
        LoyaltyTier = newTier;
    }
    #endregion

    #region Address Management
    public void AddAddress(CustomerAddress address)
    {
        // Logic to ensure only one default address exists
        if (address.IsDefault)
        {
            foreach (var addr in _addresses) 
                addr.UnsetAsDefault();
        }
        
        _addresses.Add(address);
    }

    public void RemoveAddress(Guid addressId)
    {
        var address = _addresses.FirstOrDefault(a => a.Id == addressId);
        if (address != null) _addresses.Remove(address);
    }
    #endregion
}