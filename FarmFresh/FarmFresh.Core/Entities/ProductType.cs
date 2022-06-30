using System.ComponentModel.DataAnnotations;

namespace FarmFresh.Core.Entities
{
	public class ProductType
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
