using BlazorLaboration.Entities;

namespace BlazorLaboration.Interfaces
{
	public interface IShoppingCartService
	{
		List<Product> _shoppingCartList { get; set; }
		void AddToShoppingCart(Product product);
		void RemoveFromShoppingCart(Product product, int quantity);
	}
}
