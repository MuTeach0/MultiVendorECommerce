using MultiVendor.Domain.Common;
using MultiVendor.Domain.Common.Results;
using MultiVendor.Domain.Entities.UsersContext.Users;

namespace MultiVendor.Domain.Entities.UsersContext.Sellers;

public sealed class Seller : AuditableEntity, IAggregateRoot
{
    public Guid UserId { get; private set; }
    public string StoreName { get; private set; } = string.Empty;
    public bool IsVerified { get; private set; }
    public FulfillmentType FulfillmentType { get; private set; } // 1=FBM (Seller), 2=FBS (Platform)
    public decimal RatingScore { get; private set; }

    private Seller() { }

    private Seller(Guid id, Guid userId, string storeName, FulfillmentType fulfillmentType) : base(id)
    {
        UserId = userId;
        StoreName = storeName;
        FulfillmentType = fulfillmentType;
        IsVerified = false;
        RatingScore = 0;
    }

    public static Result<Seller> Create(Guid userId, string storeName, FulfillmentType fulfillmentType)
    {
       if (userId == Guid.Empty)
            return UserErrors.InvalidUserId;

        if (string.IsNullOrWhiteSpace(storeName))
            return SellerErrors.EmptyStoreName;

        return new Seller(Guid.NewGuid(), userId, storeName, fulfillmentType);
    }

    public void Verify() => IsVerified = true;

    public Result UpdateStoreDetails(string storeName, FulfillmentType fulfillmentType)
    {
        if (string.IsNullOrWhiteSpace(storeName))
            return SellerErrors.EmptyStoreName;

        StoreName = storeName;
        FulfillmentType = fulfillmentType;
        return Result.Success();
    }

    public void UpdateRating(decimal score)
    {
        if (score >= 0 && score <= 5)
            RatingScore = score;
    }
}