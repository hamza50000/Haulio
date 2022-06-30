using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Core.Entities;
using FarmFresh.Infrastructure.Data;

namespace FarmFresh.Infrastructure.Repositories
{
	public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
	{
		public ProductDetailRepository(DataContext context) : base(context) { }


	}
}
