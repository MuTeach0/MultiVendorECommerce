using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.Sellers;

public interface ISellerOfferRepository : IRepository<SellerOffer>
{
    Task<IEnumerable<SellerOffer>> GetOffersByProductIdAsync(Guid productId);
    Task<SellerOffer?> GetBestOfferAsync(Guid productId);
}