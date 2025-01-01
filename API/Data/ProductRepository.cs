using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        #region configuration
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region Product SelectAll
        public IEnumerable<ProductModel> ProductSelectAll()
        {
            var products = new List<ProductModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new ProductModel
                {
                    ProductID = Convert.ToInt32(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString(),
                    ProductPrice = Convert.ToDouble(reader["ProductPrice"]),
                    ProductCode = reader["ProductCode"].ToString(),
                    Description = reader["Description"].ToString(),
                    UserID = Convert.ToInt32(reader["UserID"])
                });
            }
            return products;
        }
        #endregion

        #region Product Select By ID
        public ProductModel SelectByID(int id)
        {
            ProductModel product = new ProductModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_SelectByPK";
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                product.ProductID = Convert.ToInt32(reader["ProductID"]);
                product.ProductName = reader["ProductName"].ToString();
                product.ProductCode = reader["ProductCode"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"]);
                product.Description = reader["Description"].ToString();
                product.UserID = Convert.ToInt32(reader["UserID"]);
            }
            return product;
        }
        #endregion

        #region Delete Product
        public bool ProductDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_DeleteByPK";
            cmd.Parameters.AddWithValue("@ProductID", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        #endregion

        #region Insert Product
        public bool ProductInsert(ProductModel product)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_Insert";
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@UserID", product.UserID);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update Product
        public bool ProductUpdate(int id,ProductModel product)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_UpdateByPK";
            cmd.Parameters.AddWithValue("@ProductID", id);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@UserID", product.UserID);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
