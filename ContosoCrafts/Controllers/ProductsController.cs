using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService) {
            ProductService = productService;
        }
        public JsonFileProductService ProductService { get;  }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //[HttpPatch] "[FromBody]"          //change a little 
        [Route("Rate")]         //     /products/rate - this is a subroute
        [HttpGet]


        //   https://localhost:7086/products/rate?ProductId=jenlooper-cactus&rating=5
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating)
        {   
            ProductService.AddRating(ProductId,Rating);
            return Ok();
        }
    }
}
