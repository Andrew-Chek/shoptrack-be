using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
