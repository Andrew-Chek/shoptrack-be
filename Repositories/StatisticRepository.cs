using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class StatisticRepository : Repository<Statistic>
{
    public StatisticRepository(ShopTrackDbContext context) : base(context)
    {
    }
}
