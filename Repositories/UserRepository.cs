using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
