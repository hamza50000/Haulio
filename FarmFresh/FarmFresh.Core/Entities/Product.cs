using System.ComponentModel.DataAnnotations;

namespace FarmFresh.Core.Entities
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public int Quantity { get; set; }
		public int? ProductDetailId { get; set; }
		public int? ProductTypeId { get; set; }
		public ProductType ProductType { get; set; }
		public ProductDetail ProductDetail { get; set; }
	}
}
