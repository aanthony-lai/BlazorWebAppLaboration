using BlazorLaboration.Data;
using BlazorLaboration.Entities;
using BlazorLaboration.Interfaces;
using BlazorLaboration.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorLaboration.Services
{
	public class OrderService : IOrderService
	{
		private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

		public OrderService(IDbContextFactory<AppDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<int> CreateOrderAsync(OrderModel orderDetails)
		{

			using (var context = await _dbContextFactory.CreateDbContextAsync())
			{
				var order = new Order
				{
					FirstName = orderDetails.FirstName,
					LastName = orderDetails.LastName
				};

				await context.orders.AddAsync(order);
				await context.SaveChangesAsync();

				return order.OrderId;
			}
		}
	}
}
