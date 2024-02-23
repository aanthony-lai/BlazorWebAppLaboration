using BlazorLaboration.Entities;
using BlazorLaboration.Models;

namespace BlazorLaboration.Interfaces
{
	public interface IOrderService
	{
		Task<int> CreateOrderAsync(OrderModel orderDetails);

		//List<Product> ConvertShoppingCartToOrderList(Dictionary<Product, int> shoppingCart);
	}
}
