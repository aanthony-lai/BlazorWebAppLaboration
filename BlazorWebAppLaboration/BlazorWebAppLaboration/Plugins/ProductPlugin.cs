using BlazorLaboration.Data;
using BlazorLaboration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BlazorWebAppLaboration.Plugins
{
	public class ProductPlugin
	{
		private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

		public ProductPlugin(IDbContextFactory<AppDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		[KernelFunction, Description("Gets details about the products in the database.")]
		[return: Description("Details about the products.")]
		public async Task<List<Product>> GetProducts()
		{
			using var context = _dbContextFactory.CreateDbContext();
			var products = context.products.ToList();

			return products;
		}

		[KernelFunction, Description("Allows you to increase the stock on a customer's request.")]
		public async Task AddToStock(
			[Description("ID for the specific product.")] int productId,
			[Description("Quantity to add back to stock.")] int quantity)
		{
			using var context = _dbContextFactory.CreateDbContext();
			
			var product = context.products.FirstOrDefault(p => p.Id == productId);

			product.Stock += quantity;

			await context.SaveChangesAsync();
		}

		[KernelFunction, Description("Allows you to edit the description of a product")]
		public async Task EditDescription(
			[Description("ID for the specific product.")] int productId,
			[Description("New description.")] string description)
		{
			using var context = _dbContextFactory.CreateDbContext();

			var product = context.products.FirstOrDefault(p => p.Id == productId);

			product.Description = description;

			await context.SaveChangesAsync();
		}
	}
}
