using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Core.Entities;
using FarmFresh.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FarmFresh.Infrastructure.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(DataContext context) : base(context) { }

		public async Task<Product> GetProductByIdDetailAndType(int id)
		{
			return await _context.Products
				.Include(x => x.ProductDetail)
				.Include(x => x.ProductType)
				.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
