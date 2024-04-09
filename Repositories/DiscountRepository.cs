using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class DiscountRepository : Repository<Discount>
{
    public DiscountRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
