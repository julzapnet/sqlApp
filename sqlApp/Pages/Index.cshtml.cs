using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlApp.Models;
using sqlApp.Services;

namespace sqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        IProductService _productService;
        public IndexModel(IProductService productService) 
        {
            _productService = productService;
        } 
        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}