namespace MultiVendor.Domain.Entities.UsersContext.Customers;

public enum LoyaltyTier
{
    Standard = 1,   // العميل العادي
    Silver = 2,     // عميل نشط (له نسبة نقاط أعلى)
    Gold = 3,       // عميل VIP
    Ultimate = 4    // أعلى فئة (ممكن يكون ليها شحن مجاني مثلاً)
}