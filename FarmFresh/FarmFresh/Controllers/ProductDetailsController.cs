using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarmFresh.Controllers
{
	[Route("api/ProductDetails")]
	[ApiController]
	public class ProductDetailsController : ControllerBase
	{
		private readonly IProductDetailService _productDetailService;
		public ProductDetailsController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		[HttpGet("{id}")]
		public async Task<ProductDetail> Get([FromRoute] int id) => await _productDetailService.GetProductDetailById(id);

		[HttpPost]
		public async Task<ProductDetail> Add([FromBody] ProductDetail product) => await _productDetailService.AddProductDetail(product);

		[HttpPut]
		public async Task<ProductDetail> Update([FromBody] ProductDetail product) => await _productDetailService.UpdateProductDetail(product);
	}
}
