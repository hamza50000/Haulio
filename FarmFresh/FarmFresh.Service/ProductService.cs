using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFresh.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepo;

		public ProductService(IProductRepository repo)
		{
			_productRepo = repo;
		}

		public async Task<Tuple<int, IEnumerable<Product>>> GetProducts(int page, int pageSize)
		{
			var fromPage = (page - 1) * pageSize;
			var products = await _productRepo.GetAllAsync();
			var productsCount = products.Count();
			products = products.Skip(fromPage).Take(pageSize).ToList();
			if (!products.Any())
			{
				return Tuple.Create(0, Enumerable.Empty<Product>());
			}
			return Tuple.Create(productsCount, products.AsEnumerable());
		}

		public async Task<Product> GetProduct(int id) => await _productRepo.GetByIdAsync(id);

		public async Task<Product> GetProductByIdDetailAndType(int id) => await _productRepo.GetProductByIdDetailAndType(id);

		public async Task<Product> AddProduct(Product product)
		{
			var prod = await _productRepo.AddAsync(product);
			return prod;
		}

		public async Task<Product> UpdateProduct(Product obj)
		{
			var product = await _productRepo.GetByIdAsync(obj.Id);
			if (product == null)
			{
				return new Product();
			}
			product.Name = obj.Name;
			product.Quantity = obj.Quantity;

			var result = await _productRepo.UpdateAsync(product);
			return result;
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			var product = await _productRepo.GetByIdAsync(productId);
			if (product != null)
			{
				await _productRepo.DeleteAsync(product);
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
