using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.CatalogContext.Brands;

public static class BrandErrors
{
    public static Error EmptyName => Error.Validation(
        "Brand.EmptyName", 
        "Brand name cannot be empty.");

    public static Error NotFound => Error.NotFound(
        "Brand.NotFound", 
        "The specified brand was not found.");
}