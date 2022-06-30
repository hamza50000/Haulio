using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using System.Threading.Tasks;

namespace FarmFresh.Services
{
	public class ProductDetailService : IProductDetailService
	{

		private readonly IProductDetailRepository _productDetailRepo;

		public ProductDetailService(IProductDetailRepository productDetailRepo)
		{
			_productDetailRepo = productDetailRepo;
		}
		public async Task<ProductDetail> GetProductDetailById(int id) => await _productDetailRepo.GetByIdAsync(id);

		public async Task<ProductDetail> AddProductDetail(ProductDetail productDetail)
		{
			var prod = await _productDetailRepo.AddAsync(productDetail);
			return prod;
		}

		public async Task<ProductDetail> UpdateProductDetail(ProductDetail obj)
		{
			var productDetail = await _productDetailRepo.GetByIdAsync(obj.Id);
			if (productDetail == null)
			{
				return new ProductDetail();
			}
			productDetail.About = obj.About;
			productDetail.Description = obj.Description;
			productDetail.CountryOfOrigin = obj.CountryOfOrigin;

			var result = await _productDetailRepo.UpdateAsync(productDetail);
			return result;
		}
	}
}
