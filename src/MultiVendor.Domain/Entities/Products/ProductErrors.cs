using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.Products;
public static class ProductErrors
{
    public static Error EmptyName => Error.Validation("Product.EmptyName", "Product title cannot be empty.");
    public static Error EmptySku => Error.Validation("Product.EmptySku", "Master SKU is required.");
    public static Error NegativePrice => Error.Validation("Product.NegativePrice", "Price must be greater than zero.");
    public static Error InvalidStock => Error.Validation("Product.InvalidStock", "Stock cannot be negative.");
    public static Error NotFound => Error.NotFound("Product.NotFound", "Product not found.");
    public static Error EmptyDescription => Error.Validation("Product.EmptyDescription", "Product description is required.");
}