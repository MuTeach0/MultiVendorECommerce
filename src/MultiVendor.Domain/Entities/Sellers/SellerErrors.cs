using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Sellers;

public static class SellerErrors
{
    public static Error EmptyStoreName => Error.Validation("Seller.EmptyStoreName", "Store name cannot be empty.");
    public static Error InvalidRating => Error.Validation("Seller.InvalidRating", "Rating must be between 0 and 5.");
    public static Error NotFound => Error.NotFound("Seller.NotFound", "Seller not found.");
    public static Error InvalidPrice => Error.Validation("Offer.InvalidPrice", "Price must be positive.");
    public static Error InvalidStock => Error.Validation("Offer.InvalidStock", "Stock cannot be negative.");
}