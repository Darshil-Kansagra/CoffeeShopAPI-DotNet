using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        #region configuration
        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region Order SelectAll
        public IEnumerable<OrderModel> OrderSelectAll()
        {
            var Orders = new List<OrderModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Orders.Add(new OrderModel
                {
                    OrderID = Convert.ToInt32(reader["OrderID"]),
                    OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    PaymentMode = reader["PaymentMode"].ToString(),
                    TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                    ShippingAddress = reader["ShippingAddress"].ToString(),
                    UserID = Convert.ToInt32(reader["UserID"]),
                });
            }
            return Orders;
        }
        #endregion

        #region Order Select By ID
        public OrderModel SelectByID(int id)
        {
            OrderModel Order = new OrderModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_SelectByPK";
            cmd.Parameters.AddWithValue("@OrderID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Order.OrderID = Convert.ToInt32(reader["OrderID"]);
                    Order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    Order.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    Order.PaymentMode = reader["PaymentMode"].ToString();
                    Order.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                    Order.ShippingAddress = reader["ShippingAddress"].ToString();
                    Order.UserID = Convert.ToInt32(reader["UserID"]);
            }
            return Order;
        }
        #endregion

        #region Delete Order
        public bool OrderDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_DeleteByPK";
            cmd.Parameters.AddWithValue("@OrderID", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        #endregion

        #region Insert Order
        public bool OrderInsert(OrderModel Order)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_Insert";
            cmd.Parameters.AddWithValue("@OrderDate", Order.OrderDate);
            cmd.Parameters.AddWithValue("@CustomerID", Order.CustomerID);
            cmd.Parameters.AddWithValue("@PaymentMode", Order.PaymentMode);
            cmd.Parameters.AddWithValue("@TotalAmount", Order.TotalAmount);
            cmd.Parameters.AddWithValue("@ShippingAddress", Order.ShippingAddress);
            cmd.Parameters.AddWithValue("@UserID", Order.UserID);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update Order
        public bool OrderUpdate(int id, OrderModel Order)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_UpdateByPK";
            cmd.Parameters.AddWithValue("@OrderID", id);
            cmd.Parameters.AddWithValue("@OrderDate", Order.OrderDate);
            cmd.Parameters.AddWithValue("@CustomerID", Order.CustomerID);
            cmd.Parameters.AddWithValue("@PaymentMode", Order.PaymentMode);
            cmd.Parameters.AddWithValue("@TotalAmount", Order.TotalAmount);
            cmd.Parameters.AddWithValue("@ShippingAddress", Order.ShippingAddress);
            cmd.Parameters.AddWithValue("@UserID", Order.UserID);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
