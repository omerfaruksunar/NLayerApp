using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.UnitOfWorks;

namespace NLayer.Service.Services;

public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
{
	private readonly IProductRepository _productRepository;

	public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
	{
		_productRepository = productRepository;
	}

	public async Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto)
	{
		var newEntity = _mapper.Map<Product>(dto);

		await _productRepository.AddAsync(newEntity);
		await _unitOfWork.CommitAsync();

		var newDto = _mapper.Map<ProductDto>(newEntity);
		return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
	}

	public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
	{
		var products = await _productRepository.GetProductsWithCategory();
		var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
		return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
	}

	public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto)
	{
		var entity = _mapper.Map<Product>(dto);
		_productRepository.Update(entity);
		await _unitOfWork.CommitAsync();

		return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
	}
}
