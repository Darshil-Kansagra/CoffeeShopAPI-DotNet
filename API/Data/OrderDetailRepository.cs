using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data
{
    public class OrderDetailRepository
    {
        private readonly string _connectionString;

        #region configuration
        public OrderDetailRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region OrderDetail SelectAll
        public IEnumerable<OrderDetailModel> OrderDetailSelectAll()
        {
            var OrderDetails = new List<OrderDetailModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderDetails.Add(new OrderDetailModel
                {
                    OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                    OrderID = Convert.ToInt32(reader["OrderID"]),
                    ProductID = Convert.ToInt32(reader["ProductID"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Amount = Convert.ToInt32(reader["Amount"]),
                    TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                    UserID = Convert.ToInt32(reader["UserID"]),
                });
            }
            return OrderDetails;
        }
        #endregion

        #region OrderDetail Select By ID
        public OrderDetailModel SelectByID(int id)
        {
            OrderDetailModel OrderDetail = new OrderDetailModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_SelectByPK";
            cmd.Parameters.AddWithValue("@OrderDetailID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                OrderDetail.OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]);
                    OrderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                    OrderDetail.ProductID = Convert.ToInt32(reader["ProductID"]);
                    OrderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    OrderDetail.Amount = Convert.ToInt32(reader["Amount"]);
                    OrderDetail.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                    OrderDetail.UserID = Convert.ToInt32(reader["UserID"]);
            }
            return OrderDetail;
        }
        #endregion

        #region Delete OrderDetail
        public bool OrderDetailDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_DeleteByPK";
            cmd.Parameters.AddWithValue("@OrderDetailID", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        #endregion

        #region Insert OrderDetail
        public bool OrderDetailInsert(OrderDetailModel OrderDetail)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_Insert";
            cmd.Parameters.AddWithValue("@OrderID", OrderDetail.OrderID);
            cmd.Parameters.AddWithValue("@ProductID", OrderDetail.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", OrderDetail.Quantity);
            cmd.Parameters.AddWithValue("@Amount", OrderDetail.Amount);
            cmd.Parameters.AddWithValue("@TotalAmount", OrderDetail.TotalAmount);
            cmd.Parameters.AddWithValue("@UserID", OrderDetail.UserID);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update OrderDetail
        public bool OrderDetailUpdate(int id, OrderDetailModel OrderDetail)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_UpdateByPK";
            cmd.Parameters.AddWithValue("@OrderDetailID", id);
            cmd.Parameters.AddWithValue("@OrderID", OrderDetail.OrderID);
            cmd.Parameters.AddWithValue("@ProductID", OrderDetail.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", OrderDetail.Quantity);
            cmd.Parameters.AddWithValue("@Amount", OrderDetail.Amount);
            cmd.Parameters.AddWithValue("@TotalAmount", OrderDetail.TotalAmount);
            cmd.Parameters.AddWithValue("@UserID", OrderDetail.UserID);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
