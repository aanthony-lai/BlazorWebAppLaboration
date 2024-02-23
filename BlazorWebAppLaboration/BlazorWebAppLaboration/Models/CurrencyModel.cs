namespace BlazorLaboration.Models
{
	public class CurrencyModel
	{
		public double old_amount { get; set; }
		public string old_currency { get; set; } = string.Empty;
		public string new_currency {  get; set; } = string.Empty;
		public double new_amount { get; set; }
	}
}
