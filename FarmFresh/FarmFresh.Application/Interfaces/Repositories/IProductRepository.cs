using FarmFresh.Core.Entities;
using System.Threading.Tasks;

namespace FarmFresh.Application.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<Product> GetProductByIdDetailAndType(int id);
	}
}
