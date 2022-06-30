using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmFresh.Controllers
{
	[Route("api/ProductTypes")]
	[ApiController]
	public class ProductTypesController : ControllerBase
	{
		private readonly IProductTypeService _productTypeService;
		public ProductTypesController(IProductTypeService productTypeService)
		{
			_productTypeService = productTypeService;
		}
		[HttpGet]
		public async Task<IEnumerable<ProductType>> Get() => await _productTypeService.GetProductTypes();

		[HttpGet("{id}")]
		public async Task<ProductType> Get([FromRoute] int id) => await _productTypeService.GetProductTypeById(id);

		[HttpPost]
		public async Task<ProductType> Add([FromBody] ProductType product) => await _productTypeService.AddProductType(product);

		[HttpPut]
		public async Task<ProductType> Update([FromBody] ProductType product) => await _productTypeService.UpdateProductType(product);

		[HttpDelete("{id}")]
		public async Task<bool> Delete([FromRoute] int id) => await _productTypeService.DeleteProductType(id);
	}
}
