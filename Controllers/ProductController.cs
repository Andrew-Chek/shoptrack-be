using shoptrack_be.Controllers;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

[Microsoft.AspNetCore.Mvc.Route("api/products")]
public class ProductController : CrudController<Product, ProductRepository>
{
    public ProductController(ProductRepository productRepository) : base(productRepository)
    {
    }
}
