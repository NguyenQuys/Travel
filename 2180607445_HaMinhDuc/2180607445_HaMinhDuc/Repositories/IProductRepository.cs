using _2180607445_HaMinhDuc.Models;

namespace _2180607445_HaMinhDuc.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(int id);
		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(int id);
	}
}
