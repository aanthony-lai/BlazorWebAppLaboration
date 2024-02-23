using BlazorLaboration.Entities;
using BlazorLaboration.Interfaces;

namespace BlazorLaboration.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IProductService _productService;
		public List<Product> _shoppingCartList { get; set; } = new List<Product>();

		public ShoppingCartService(IProductService productService)
		{
			_productService = productService;
		}

		public void AddToShoppingCart(Product product)
		{
			if (_shoppingCartList.Any(p => p.Id == product.Id))
			{
				var itemInCart = _shoppingCartList.FirstOrDefault(p => p.Id == product.Id)
					?? new Product();

				itemInCart.Stock += 1;
				return;
			}

			product.Stock = 1;
			_shoppingCartList.Add(product);
		}

		public void RemoveFromShoppingCart(Product product, int quantity)
		{
			_productService.AddToStockAsync(product, quantity);
			_shoppingCartList.Remove(product);
		}
	}
}
