using sqlApp.Models;

namespace sqlApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}