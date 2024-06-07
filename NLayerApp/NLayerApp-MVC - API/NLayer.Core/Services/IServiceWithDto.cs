using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System.Linq.Expressions;

namespace NLayer.Core.Services;

public interface IServiceWithDto<TEntity,Dto> where TEntity : BaseEntity where Dto : class
{
	Task<CustomResponseDto<Dto>> GetByIdAsync(int id);
	Task <CustomResponseDto<IEnumerable<Dto>>> GetAllAsync();
	Task <CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<TEntity, bool>> expression);
	Task <CustomResponseDto<bool>> AnyAsync(Expression<Func<TEntity, bool>> expression);
	Task <CustomResponseDto<Dto>> AddAsync(Dto dto);
	Task <CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos);
	Task <CustomResponseDto<NoContentDto>> UpdateAsync(Dto dto);
	Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id);
	Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<int> ids);
}
