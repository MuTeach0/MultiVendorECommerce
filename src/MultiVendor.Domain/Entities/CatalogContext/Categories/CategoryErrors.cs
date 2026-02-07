using MultiVendor.Domain.Common.Results;

namespace MultiVendor.Domain.Entities.CatalogContext.Categories;

public static class CategoryErrors
{
    public static Error EmptyName => Error.Validation(
        "Category.EmptyName", 
        "Category name cannot be empty.");

    public static Error NameTooLong => Error.Validation(
        "Category.NameTooLong", 
        "Category name is too long.");

    public static Error NotFound => Error.NotFound(
        "Category.NotFound", 
        "The specified category was not found.");
}