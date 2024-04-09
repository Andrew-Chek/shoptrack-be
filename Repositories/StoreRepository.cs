using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class StoreRepository : Repository<Store>
{
    public StoreRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
