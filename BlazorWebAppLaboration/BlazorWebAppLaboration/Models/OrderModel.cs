using System.ComponentModel.DataAnnotations;

namespace BlazorLaboration.Models
{
	public class OrderModel
	{
		[Required]
		public string? FirstName { get; set; }

		[Required]
		public string? LastName { get; set; }

		[Required]
		public string? Address { get; set; }

		[Required]
		[EmailAddress]
		public string? Email { get; set; }
	}
}
