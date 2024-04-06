using _2180607445_HaMinhDuc.Models;

namespace _2180607445_HaMinhDuc.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category> GetByIdAsync(int id);
		Task AddAsync(Category category);
		Task UpdateAsync(Category category);
		Task DeleteAsync(int id);
	}
}
