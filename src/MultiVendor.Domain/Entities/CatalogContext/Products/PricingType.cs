namespace MultiVendor.Domain.Entities.CatalogContext.Products;

public enum PricingType
{
    Fixed = 1,      // سعر ثابت للمنتج
    Attribute = 2,  // السعر يعتمد على الخصائص (زي المقاس واللون)
    Quantity = 3,   // خصم كمية
    Hybrid = 4      // هجين بين الأنواع
}