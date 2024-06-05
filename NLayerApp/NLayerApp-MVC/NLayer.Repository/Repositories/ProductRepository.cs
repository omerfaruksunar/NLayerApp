using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithCategory()
    {
        //Eager Loading = Burada kullandigimiz gibi ilk Productları cektitigimiz anda category'i de cekersek Eager Loading olmus olur.
        //Lazy Loading = İhtiyac oldugunda daha sonra cekilirse o da lazy loading olur.
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }
}
