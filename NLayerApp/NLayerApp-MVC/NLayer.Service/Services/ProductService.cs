using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Services;
using NLayer.Core.DTOs;
using AutoMapper;

namespace NLayer.Service.Services;

public class ProductServiceWithNoCaching : Service<Product>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductServiceWithNoCaching(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IMapper mapper, IProductRepository productRepository) : base(unitOfWork, repository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
    {
        var products = await _productRepository.GetProductsWithCategory();
        var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(products);
        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
    }
}
