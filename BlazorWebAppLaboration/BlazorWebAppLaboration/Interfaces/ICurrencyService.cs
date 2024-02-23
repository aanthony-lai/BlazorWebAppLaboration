using BlazorLaboration.Entities;

namespace BlazorLaboration.Interfaces
{
	public interface ICurrencyService
	{
		Task<double> GetExchangeRateAsync(string have, string want, double amount);
		Task<List<Product>> ConvertProductsCurrencyAsync(string selectedCurrency, List<Product> products);
		Task<Product> ConvertSingleProductCurrencyAsync(string selectedCurrency, Product product);
		string InitialCurrency { get; }
		string SelectedCurrency { get; set; }
	}
}
