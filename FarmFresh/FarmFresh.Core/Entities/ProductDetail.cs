using System.ComponentModel.DataAnnotations;

namespace FarmFresh.Core.Entities
{
	public class ProductDetail
	{
		[Key]
		public int Id { get; set; }
		public string About { get; set; }
		public string Description { get; set; }
		public string CountryOfOrigin { get; set; }
		public Product Product { get; set; }
	}
}
