using BlazorLaboration.Entities;
using BlazorLaboration.Interfaces;
using BlazorLaboration.Models;

namespace BlazorLaboration.Services
{
	public class CurrencyService : ICurrencyService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;
		private readonly string ApiKey;
		public string InitialCurrency { get; } = "USD";
		public string SelectedCurrency { get; set; } = "USD";

		public CurrencyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
			ApiKey = _configuration.GetSection("ApiKey").Value
				?? string.Empty;
		}

		public async Task<double> GetExchangeRateAsync(string have, string want, double amount)
		{
			var client = _httpClientFactory.CreateClient("CurrencyAPI");
			client.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);

			var response = await client.GetFromJsonAsync<CurrencyModel>($"https://api.api-ninjas.com/v1/convertcurrency?have={have}&want={want}&amount={Math.Round(amount)}")
				?? throw new Exception();

			return response.new_amount;
		}

		public async Task<List<Product>> ConvertProductsCurrencyAsync(string selectedCurrency, List<Product> products)
		{
			foreach (var product in products)
			{
				product.Price = await GetExchangeRateAsync(InitialCurrency, selectedCurrency, product.Price);
			}
			SelectedCurrency = selectedCurrency;

			return products;
		}

		public async Task<Product> ConvertSingleProductCurrencyAsync(string selectedCurrency, Product product)
		{
			product.Price = await GetExchangeRateAsync(InitialCurrency, selectedCurrency, product.Price);
			SelectedCurrency = selectedCurrency;

			return product;
		}
	}
}
