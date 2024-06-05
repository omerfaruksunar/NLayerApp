using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
    {
        //First or default birden fazla olsa da ilkini doner burada SingleOrDefault kullanmamizin sebebi birden fazla bulursa hata doner bizim id degerimiz primary key oldugu icin tek bir tane olması gerekir. Birden fazla olursa hata donecegi icin SingleOrDefaultAsync kullanmamiz daha mantikli.
        return await _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
    }
}
