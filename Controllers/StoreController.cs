using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/stores")]
public class StoreController : CrudController<Store, StoreRepository>
{
    public StoreController(StoreRepository storeRepository) : base(storeRepository)
    {
    }
}
