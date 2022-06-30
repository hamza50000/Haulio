using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmFresh.Services
{
	public class ProductTypeService : IProductTypeService
	{

		private readonly IProductTypeRepository _productTypeRepo;

		public ProductTypeService(IProductTypeRepository productTypeRepo)
		{
			_productTypeRepo = productTypeRepo;
		}

		public async Task<IEnumerable<ProductType>> GetProductTypes() => await _productTypeRepo.GetAllAsync();

		public async Task<ProductType> GetProductTypeById(int id) => await _productTypeRepo.GetByIdAsync(id);

		public async Task<ProductType> AddProductType(ProductType productType)
		{
			var prod = await _productTypeRepo.AddAsync(productType);
			return prod;
		}

		public async Task<ProductType> UpdateProductType(ProductType obj)
		{
			var productType = await _productTypeRepo.GetByIdAsync(obj.Id);
			if (productType == null)
			{
				return new ProductType();
			}
			productType.Name = obj.Name;

			var result = await _productTypeRepo.UpdateAsync(productType);
			return result;
		}

		public async Task<bool> DeleteProductType(int productTypeId)
		{
			var productType = await _productTypeRepo.GetByIdAsync(productTypeId);
			if (productType != null)
			{
				await _productTypeRepo.DeleteAsync(productType);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
