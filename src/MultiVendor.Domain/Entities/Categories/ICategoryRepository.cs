using MultiVendor.Domain.Common;

namespace MultiVendor.Domain.Entities.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetActiveCategoriesAsync(CancellationToken cancellationToken = default);
}