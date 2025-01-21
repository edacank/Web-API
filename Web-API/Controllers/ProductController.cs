using Microsoft.AspNetCore.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{
    //localhost:5000/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product>? _products;

        public ProductController()
        {
            _products = new List<Product> {
            new() { ProductId =1,ProductName ="earphone", Price=500,IsActive=true},
            new() { ProductId =2,ProductName ="mouse", Price=400,IsActive=true}
            };
        }
    

    //localhost:5000//api/products => GET
    [HttpGet]
    public IActionResult GetProducts()
        {
            if (_products == null)
            {
                return NotFound();
            }
            return Ok(_products);
        }
    //public List<Product> GetProducts()
    //{
    //    return _products ?? new List<Product>();
    //}
    //localhost:5000/api/products/1 =>
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
            if (id == null)
            {
                return NotFound();
            }
            var p = _products?.FirstOrDefault(i => i.ProductId == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
       // return _products.FirstOrDefault(i =>i.ProductId == id) ??  new Product();
    }


    }
}
