using BlazorLaboration.Data;
using BlazorLaboration.Entities;
using BlazorLaboration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorLaboration.Services
{
	public class ProductService : IProductService
	{
		private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
		private readonly ICurrencyService _currencyService;

		public ProductService(IDbContextFactory<AppDbContext> dbContextFactory, ICurrencyService currencyService) 
		{
			_dbContextFactory = dbContextFactory;
			_currencyService = currencyService;
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			using var context = await _dbContextFactory.CreateDbContextAsync();

			var result = context.products.ToList()
					?? new List<Product>();

			return result;
		}

        public async Task<List<Product>> GetProductsAsync(string selectedCurrency)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var result = context.products.ToList()
                    ?? new List<Product>();

			if (selectedCurrency == _currencyService.InitialCurrency)
			{
				return result;
			}

			result = await _currencyService.ConvertProductsCurrencyAsync(selectedCurrency, result);
			return result;
		}

        public async Task<Product> GetProductByIdAsync(int id)
		{
			using var context = await _dbContextFactory.CreateDbContextAsync();

			var result = context.products.FirstOrDefault(x => x.Id == id)
				?? new Product();

			return result;
		}

        public async Task<Product> GetProductByIdAsync(int id, string selectedCurrency)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var result = context.products.FirstOrDefault(x => x.Id == id)
                ?? new Product();

			if(selectedCurrency == _currencyService.InitialCurrency)
			{
				return result;
			}

			result = await _currencyService.ConvertSingleProductCurrencyAsync(selectedCurrency, result);
            return result;
        }

        public async Task<bool> SubtractFromStockAsync(Product product)
		{
			using var context = await _dbContextFactory.CreateDbContextAsync();

			var result = context.products.FirstOrDefault(p => p.Id == product.Id)
				?? new Product();

			if (result.Stock <= 0)
			{
				return false;
			}

			result.Stock -= 1;
			await context.SaveChangesAsync();
			return true;
		}

		public async Task AddToStockAsync(Product product, int quantity)
		{
			using var context = await _dbContextFactory.CreateDbContextAsync();

			var result = context.products.FirstOrDefault(p => p.Id == product.Id)
				?? new Product();

			result.Stock += quantity;
			await context.SaveChangesAsync();
		}
	}
}
