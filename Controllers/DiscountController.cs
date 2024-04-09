using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/discounts")]
public class DiscountController : CrudController<Discount, DiscountRepository>
{
    public DiscountController(DiscountRepository discountRepository) : base(discountRepository)
    {
    }
}
