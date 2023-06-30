using System.Data.SqlClient;
using Microsoft.FeatureManagement;
using sqlApp.Models;

namespace sqlApp.Services
{
    public class ProductService : IProductService
    {
        private IConfiguration _configuration;
        private IFeatureManager _featureManager;
        public ProductService(IConfiguration configuration,IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public async Task<bool> IsBeta()
        {
            if(await _featureManager.IsEnabledAsync("beta")) { 
                return true;
            }
            else
            {
                return false;
            }
        }

        private SqlConnection GetConnection()
        {
            //return new SqlConnection(_configuration.GetConnectionString("SQLConnectionString"));
            return new SqlConnection(_configuration["SQLConnectionString"]);
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
