using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlApp.Models;
using sqlApp.Services;

namespace sqlApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        public bool IsBeta;
        IProductService _productService;
        public IndexModel(IProductService productService) 
        {
            _productService = productService;
        } 
        public void OnGet()
        {
            IsBeta= _productService.IsBeta().Result;
            Products = _productService.GetProducts();
        }
    }
}