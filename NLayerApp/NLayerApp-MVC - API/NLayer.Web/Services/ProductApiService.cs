using NLayer.Core.DTOs;

namespace NLayer.Web.Services;

public class ProductApiService
{
	private readonly HttpClient _httpClient;
	public ProductApiService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
	{
		var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("products/GetProductsWithCategory");

		return response.Data;
	}

	public async Task<ProductDto> GetByIdAsync(int id)
	{
		var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");

		if (response.Errors != null && response.Errors.Any())
		{

			var errorMessage = string.Join(", ", response.Errors);
			throw new Exception($"Error fetching product with id {id}: {errorMessage}");
		}
		else
		{
			return response.Data;
		}
	}

	public async Task<ProductDto> SaveAsync(ProductDto newProduct)
	{
		var response = await _httpClient.PostAsJsonAsync("Products", newProduct);

		if (!response.IsSuccessStatusCode) return null;

		var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

		return responseBody.Data;
	}

	public async Task<bool> UpdateAsync(ProductDto newProduct)
	{
		var response= await _httpClient.PutAsJsonAsync("Products", newProduct);

		return response.IsSuccessStatusCode;
	}

	public async Task<bool> RemoveAsync(int id)
	{
		var response = await _httpClient.DeleteAsync($"Products/{id}");

		return response.IsSuccessStatusCode;
	}
}
