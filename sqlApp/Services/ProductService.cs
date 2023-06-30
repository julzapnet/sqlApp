using System.Data.SqlClient;
using sqlApp.Models;

namespace sqlApp.Services
{
    public class ProductService : IProductService
    {
        private IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
           return new SqlConnection(_configuration.GetConnectionString("SQLConnectionString"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> _productList = new List<Product>();

            string statement = "SELECT ProductId, ProductName,Quantity from Products";
            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    _productList.Add(new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    });
                }
            }
            conn.Close();
            return _productList;
        }
    }
}
