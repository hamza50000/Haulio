using FarmFresh.Core.Entities;
using System.Threading.Tasks;

namespace FarmFresh.Application.Interfaces.Services
{
	public interface IProductDetailService
	{
		Task<ProductDetail> GetProductDetailById(int id);
		Task<ProductDetail> AddProductDetail(ProductDetail productDetail);
		Task<ProductDetail> UpdateProductDetail(ProductDetail obj);
	}
}
