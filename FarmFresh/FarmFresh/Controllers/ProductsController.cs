using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmFresh.Controllers
{
	[Route("api/Products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<Tuple<int, IEnumerable<Product>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
			=> await _productService.GetProducts(page, pageSize);

		[HttpGet("{id}")]
		public async Task<Product> Get([FromRoute] int id) => await _productService.GetProduct(id);

		[HttpGet("{id}/Detail/Type")]
		public async Task<Product> GetProductDetailType([FromRoute] int id) => await _productService.GetProductByIdDetailAndType(id);

		[HttpPost]
		public async Task<Product> Add([FromBody] Product product) => await _productService.AddProduct(product);

		[HttpPut]
		public async Task<Product> Update([FromBody] Product product) => await _productService.UpdateProduct(product);

		[HttpDelete("{id}")]
		public async Task<bool> Delete([FromRoute] int id) => await _productService.DeleteProduct(id);
	}
}
