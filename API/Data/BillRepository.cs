using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Data
{
    public class BillRepository
    {
        private readonly string _connectionString;

        #region configuration
        public BillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region Bill SelectAll
        public IEnumerable<BillModel> BillSelectAll()
        {
            var Bills = new List<BillModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Bills.Add(new BillModel
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    BillNumber = reader["BillNumber"].ToString(),
                    BillDate = Convert.ToDateTime(reader["BillDate"]),
                    OrderID = Convert.ToInt32(reader["OrderID"]),
                    TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                    Discount = Convert.ToInt32(reader["Discount"]),
                    NetAmount = Convert.ToInt32(reader["NetAmount"]),
                    UserID = Convert.ToInt32(reader["UserID"]),
                });
            }
            return Bills;
        }
        #endregion

        #region Bill Select By ID
        public BillModel SelectByID(int id)
        {
            BillModel Bill = new BillModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_SelectByPK";
            cmd.Parameters.AddWithValue("@BillID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bill.BillID = Convert.ToInt32(reader["BillID"]);
                    Bill.BillNumber = reader["BillNumber"].ToString();
                    Bill.BillDate = Convert.ToDateTime(reader["BillDate"]);
                    Bill.OrderID = Convert.ToInt32(reader["OrderID"]);
                    Bill.TotalAmount = Convert.ToInt32(reader["TotalAmount"]);
                    Bill.Discount = Convert.ToInt32(reader["Discount"]);
                    Bill.NetAmount = Convert.ToInt32(reader["NetAmount"]);
                    Bill.UserID = Convert.ToInt32(reader["UserID"]);
            }
            return Bill;
        }
        #endregion

        #region Delete Bill
        public bool BillDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_DeleteByPK";
            cmd.Parameters.AddWithValue("@BillID", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        #endregion

        #region Insert Bill
        public bool BillInsert(BillModel Bill)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_Insert";
            cmd.Parameters.AddWithValue("@BillNumber", Bill.BillNumber);
            cmd.Parameters.AddWithValue("@BillDate", Bill.BillDate);
            cmd.Parameters.AddWithValue("@OrderID", Bill.OrderID);
            cmd.Parameters.AddWithValue("@TotalAmount", Bill.TotalAmount);
            cmd.Parameters.AddWithValue("@Discount", Bill.Discount);
            cmd.Parameters.AddWithValue("@NetAmount", Bill.NetAmount);
            cmd.Parameters.AddWithValue("@UserID", Bill.UserID);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update Bill
        public bool BillUpdate(int id, BillModel Bill)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_UpdateByPK";
            cmd.Parameters.AddWithValue("@BillID", id);
            cmd.Parameters.AddWithValue("@BillNumber", Bill.BillNumber);
            cmd.Parameters.AddWithValue("@BillDate", Bill.BillDate);
            cmd.Parameters.AddWithValue("@OrderID", Bill.OrderID);
            cmd.Parameters.AddWithValue("@TotalAmount", Bill.TotalAmount);
            cmd.Parameters.AddWithValue("@Discount", Bill.Discount);
            cmd.Parameters.AddWithValue("@NetAmount", Bill.NetAmount);
            cmd.Parameters.AddWithValue("@UserID", Bill.UserID);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
