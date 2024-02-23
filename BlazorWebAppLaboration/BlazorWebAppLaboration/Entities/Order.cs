using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLaboration.Entities
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		//public string Address {  get; set; } = string.Empty;

		//public string Email { get; set; } = string.Empty;
	}
}
