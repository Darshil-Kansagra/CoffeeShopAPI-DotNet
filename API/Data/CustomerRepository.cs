using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data
{
    public class CustomerRepository
    {
        private readonly string _connectionString;

        #region configuration
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region Customer SelectAll
        public IEnumerable<CustomerModel> CustomerSelectAll()
        {
            var Customers = new List<CustomerModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customers.Add(new CustomerModel
                {
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerName = reader["CustomerName"].ToString(),
                    HomeAddress = reader["HomeAddress"].ToString(),
                    Email = reader["Email"].ToString(),
                    MobileNo = reader["MobileNo"].ToString(),
                    GSTNO = reader["GSTNO"].ToString(),
                    CityName = reader["CityName"].ToString(),
                    NetAmount = Convert.ToInt32(reader["NetAmount"]),
                    PinCode = reader["PinCode"].ToString(),
                    UserID = Convert.ToInt32(reader["UserID"]),
                });
            }
            return Customers;
        }
        #endregion

        #region Customer Select By ID
        public CustomerModel SelectByID(int id)
        {
            CustomerModel Customer = new CustomerModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_SelectByPK";
            cmd.Parameters.AddWithValue("@CustomerID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    Customer.CustomerName = reader["CustomerName"].ToString();
                    Customer.HomeAddress = reader["HomeAddress"].ToString();
                    Customer.Email = reader["Email"].ToString();
                    Customer.MobileNo = reader["MobileNo"].ToString();
                    Customer.GSTNO = reader["GSTNO"].ToString();
                    Customer.CityName = reader["CityName"].ToString();
                    Customer.NetAmount = Convert.ToInt32(reader["NetAmount"]);
                    Customer.PinCode = reader["PinCode"].ToString();
                    Customer.UserID = Convert.ToInt32(reader["UserID"]);
            }   
            return Customer;
        }
        #endregion

        #region Delete Customer
        public bool CustomerDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_DeleteByPK";
            cmd.Parameters.AddWithValue("@CustomerID", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        #endregion

        #region Insert Customer
        public bool CustomerInsert(CustomerModel Customer)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_Insert";
            cmd.Parameters.AddWithValue("@CustomerName", Customer.CustomerName);
            cmd.Parameters.AddWithValue("@HomeAddress", Customer.HomeAddress);
            cmd.Parameters.AddWithValue("@Email", Customer.Email);
            cmd.Parameters.AddWithValue("@MobileNo", Customer.MobileNo);
            cmd.Parameters.AddWithValue("@GSTNO", Customer.GSTNO);
            cmd.Parameters.AddWithValue("@NetAmount", Customer.NetAmount);
            cmd.Parameters.AddWithValue("@PinCode", Customer.PinCode);
            cmd.Parameters.AddWithValue("@CityName", Customer.CityName);
            cmd.Parameters.AddWithValue("@UserID", Customer.UserID);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update Customer
        public bool CustomerUpdate(int id, CustomerModel Customer)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_UpdateByPK";
            cmd.Parameters.AddWithValue("@CustomerID", id);
            cmd.Parameters.AddWithValue("@CustomerName", Customer.CustomerName);
            cmd.Parameters.AddWithValue("@HomeAddress", Customer.HomeAddress);
            cmd.Parameters.AddWithValue("@Email", Customer.Email);
            cmd.Parameters.AddWithValue("@MobileNo", Customer.MobileNo);
            cmd.Parameters.AddWithValue("@GSTNO", Customer.GSTNO);
            cmd.Parameters.AddWithValue("@NetAmount", Customer.NetAmount);
            cmd.Parameters.AddWithValue("@PinCode", Customer.PinCode);
            cmd.Parameters.AddWithValue("@CityName", Customer.CityName);
            cmd.Parameters.AddWithValue("@UserID", Customer.UserID);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
