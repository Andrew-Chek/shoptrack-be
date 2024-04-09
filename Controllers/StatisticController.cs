using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/statistics")]
public class StatisticController : CrudController<Statistic, StatisticRepository>
{
    public StatisticController(StatisticRepository statisticRepository) : base(statisticRepository)
    {
    }
}
