using API.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace API.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        #region configuration
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region User SelectAll
        public IEnumerable<UserModel> UserSelectAll()
        {
            var user = new List<UserModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_User_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new UserModel
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    UserName = reader["UserName"].ToString().Trim(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    MobileNo = reader["MobileNo"].ToString(),
                    Address = reader["Address"].ToString(),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),

                });
            }
            return user;
        }
        #endregion

        #region User Select By ID
        public UserModel SelectByID(int id)
        {
            UserModel User = new UserModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_User_SelectByPK";
            cmd.Parameters.AddWithValue("@UserID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User.UserID = Convert.ToInt32(reader["UserID"]);
                User.UserName = reader["UserName"].ToString().Trim();
                User.Email = reader["Email"].ToString();
                User.Password = reader["Password"].ToString();
                User.MobileNo = reader["MobileNo"].ToString();
                User.Address = reader["Address"].ToString();
                User.IsActive = Convert.ToBoolean(reader["IsActive"]);
            }
            return User;
        }
        #endregion

        #region Delete User
        public bool UserDelete(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_User_Delete";
            cmd.Parameters.AddWithValue("@UserID", id);
            int deleteRow = cmd.ExecuteNonQuery();
            return deleteRow > 0;
        }
        #endregion

        #region Insert User
        public bool UserInsert(UserModel UserModel)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_User_Insert";
            cmd.Parameters.AddWithValue("@UserName", UserModel.UserName);
            cmd.Parameters.AddWithValue("@Email", UserModel.Email);
            cmd.Parameters.AddWithValue("@Password", UserModel.Password);
            cmd.Parameters.AddWithValue("@MobileNo", UserModel.MobileNo);
            cmd.Parameters.AddWithValue("@Address", UserModel.Address);
            cmd.Parameters.AddWithValue("@IsActive", UserModel.IsActive);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update User
        public bool UserUpdate(int id, UserModel UserModel)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_User_Update";
            cmd.Parameters.AddWithValue("@UserID", id);
            cmd.Parameters.AddWithValue("@UserName", UserModel.UserName);
            cmd.Parameters.AddWithValue("@Email", UserModel.Email);
            cmd.Parameters.AddWithValue("@Password", UserModel.Password);
            cmd.Parameters.AddWithValue("@MobileNo", UserModel.MobileNo);
            cmd.Parameters.AddWithValue("@Address", UserModel.Address);
            cmd.Parameters.AddWithValue("@IsActive", UserModel.IsActive);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion
    }
}
