using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/purchases")]
public class PurchaseController : CrudController<Purchase, PurchaseRepository>
{
    public PurchaseController(PurchaseRepository purchaseRepository) : base(purchaseRepository)
    {
    }
}
