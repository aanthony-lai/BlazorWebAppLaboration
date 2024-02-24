using BlazorLaboration.Entities;

namespace BlazorLaboration.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsAsync(string selectedCurrency);
        Task<Product> GetProductByIdAsync(int id);
		Task<Product> GetProductByIdAsync(int id, string selectedCurrency);
        Task<bool> SubtractFromStockAsync(Product product);
		Task AddToStockAsync(Product product, int quantity);
	}
}
