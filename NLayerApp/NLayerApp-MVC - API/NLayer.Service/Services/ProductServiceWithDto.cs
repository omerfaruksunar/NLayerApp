using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Service.Services;

public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
{
	public ProductServiceWithDto()
	{
	}

	public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
	{
		throw new NotImplementedException();
	}
}
