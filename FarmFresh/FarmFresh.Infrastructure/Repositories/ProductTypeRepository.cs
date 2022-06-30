using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Core.Entities;
using FarmFresh.Infrastructure.Data;

namespace FarmFresh.Infrastructure.Repositories
{
	public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
	{
		public ProductTypeRepository(DataContext context) : base(context) { }


	}
}
