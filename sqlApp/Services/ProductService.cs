using System.Data.SqlClient;
using sqlApp.Models;

namespace sqlApp.Services
{
    public class ProductService
    {
        private static string db_source = "testdbjzapata.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Todita.2015$";
        private static string db_database = "TestDatabaseJZ";

        private SqlConnection GetConnection()
        {
           var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> _productList= new List<Product>();

            string statement = "SELECT ProductId, ProductName,Quantity from Products";
            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    _productList.Add(new Product()
                    {
                        ProductId=reader.GetInt32(0),
                        ProductName=reader.GetString(1),
                        Quantity=reader.GetInt32(2),
                    });
                }
            }
            conn.Close();
            return _productList;
        }
    }
}
