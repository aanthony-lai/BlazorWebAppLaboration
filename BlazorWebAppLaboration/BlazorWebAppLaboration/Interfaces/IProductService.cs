using BlazorLaboration.Entities;

namespace BlazorLaboration.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task<Product> GetProductByIdAsync(int id);
		Task<bool> SubtractFromStockAsync(Product product);
		Task AddToStockAsync(Product product, int quantity);
	}
}
