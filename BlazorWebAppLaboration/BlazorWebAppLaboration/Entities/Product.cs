using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLaboration.Entities
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string ImageURL { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public double Price { get; set; }
		public int Stock {  get; set; }
	}
}
