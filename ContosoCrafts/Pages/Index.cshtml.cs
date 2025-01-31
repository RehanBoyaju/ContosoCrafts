using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product>? Products { get; private set; }
        
        //Declaring to asp dot net i need some stuff go get it
        public IndexModel(ILogger<IndexModel> logger,JsonFileProductService jsonFileProductService)
        {
            _logger = logger;
            ProductService=jsonFileProductService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
