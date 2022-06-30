using FarmFresh.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmFresh.Application.Interfaces.Services
{
	public interface IProductTypeService
	{
		Task<IEnumerable<ProductType>> GetProductTypes();
		Task<ProductType> GetProductTypeById(int id);
		Task<ProductType> AddProductType(ProductType productType);
		Task<ProductType> UpdateProductType(ProductType obj);
		Task<bool> DeleteProductType(int productTypeId);
	}
}
