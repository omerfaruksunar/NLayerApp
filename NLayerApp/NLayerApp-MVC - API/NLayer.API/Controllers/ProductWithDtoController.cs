using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductWithDtoController : CustomBaseController
	{
		private readonly IProductServiceWithDto _productServiceWithDto;

		public ProductWithDtoController(IProductServiceWithDto productServiceWithDto)
		{
			_productServiceWithDto = productServiceWithDto;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetProductsWithCategory()
		{
			return CreateActionResult(await _productServiceWithDto.GetProductsWithCategory());
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			return CreateActionResult(await _productServiceWithDto.GetAllAsync());
		}

		[ServiceFilter(typeof(NotFoundFilter<Product>))]
		//GET www.mysite.com/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return CreateActionResult(await _productServiceWithDto.GetByIdAsync(id));
		}


		[HttpPost]
		public async Task<IActionResult> Save(ProductCreateDto productDto)
		{
			return CreateActionResult(await _productServiceWithDto.AddAsync(productDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
		{
			return CreateActionResult(await _productServiceWithDto.UpdateAsync(productUpdateDto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			return CreateActionResult(await _productServiceWithDto.RemoveAsync(id));
		}

		[HttpPost("SaveAll")]
		public async Task<IActionResult> Save(List<ProductDto> productDtos)
		{
			return CreateActionResult(await _productServiceWithDto.AddRangeAsync(productDtos));
		}

		[HttpPost("RemoveAll")]
		public async Task<IActionResult> RemoveAll(List<int> ids)
		{
			return CreateActionResult(await _productServiceWithDto.RemoveRangeAsync(ids));
		}

		[HttpPost("Any/{id}")]
		public async Task<IActionResult> Any(int id)
		{
			return CreateActionResult(await _productServiceWithDto.AnyAsync(x=>x.Id==id));
		}
	}
}
