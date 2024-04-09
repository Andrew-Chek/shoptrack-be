using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class PurchaseRepository : Repository<Purchase>
{
    public PurchaseRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
