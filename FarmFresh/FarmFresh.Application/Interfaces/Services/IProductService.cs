using FarmFresh.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmFresh.Application.Interfaces.Services
{
	public interface IProductService
	{
		Task<Tuple<int, IEnumerable<Product>>> GetProducts(int page, int pageSize);
		Task<Product> GetProduct(int id);
		Task<Product> AddProduct(Product product);
		Task<Product> UpdateProduct(Product obj);
		Task<bool> DeleteProduct(int productId);
		Task<Product> GetProductByIdDetailAndType(int id);
	}
}
