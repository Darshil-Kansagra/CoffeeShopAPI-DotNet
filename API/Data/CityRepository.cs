using System.Data;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class CityRepository
    {
        private readonly string _connectionString;

        #region configuration
        public CityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region City SelectAll
        public IEnumerable<CityModel> SelectAll()
        {
            var cities = new List<CityModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cities.Add(new CityModel
                {
                    CityID = Convert.ToInt32(reader["CityID"]),
                    CityName = reader["CityName"].ToString().Trim(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    CityCode = reader["CityCode"].ToString(),
                });
            }
            return cities;
        }
        #endregion

        #region City Select By ID
        public CityModel SelectByID(int id)
        {
            CityModel city = new CityModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_SelectByPK";
            cmd.Parameters.AddWithValue("@CityID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                city.CityID = Convert.ToInt32(reader["CityID"]);
                city.CityName = reader["CityName"].ToString().Trim();
                city.CountryID = Convert.ToInt32(reader["CountryID"]);
                city.StateID = Convert.ToInt32(reader["StateID"]);
                city.CityCode = reader["CityCode"].ToString();
            }
            return city;
        }
        #endregion

        #region Delete City
        public bool DeleteCity(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_Delete";
            cmd.Parameters.AddWithValue("@CityID", id);
            int deleteRow = cmd.ExecuteNonQuery();
            return deleteRow > 0;
        }
        #endregion

        #region Insert City
        public bool InsertCity(CityModel cityModel)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_Insert";
            cmd.Parameters.AddWithValue("@CityName", cityModel.CityName);
            cmd.Parameters.AddWithValue("@CountryID", cityModel.CountryID);
            cmd.Parameters.AddWithValue("@StateID", cityModel.StateID);
            cmd.Parameters.AddWithValue("@CityCode", cityModel.CityCode);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update City
        public bool UpdateCity(int id, CityModel cityModel)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_Update";
            cmd.Parameters.AddWithValue("@CityID", id);
            cmd.Parameters.AddWithValue("@CityName", cityModel.CityName);
            cmd.Parameters.AddWithValue("@CountryID", cityModel.CountryID);
            cmd.Parameters.AddWithValue("@StateID", cityModel.StateID);
            cmd.Parameters.AddWithValue("@CityCode", cityModel.CityCode);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;
        }
        #endregion

        #region Country Drop Down
        public IEnumerable<CountryDropDownModel> CountrySelectAll()
        {
            var countries = new List<CountryDropDownModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_Country_SelectComboBox";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryDropDownModel
                {
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                });
            }
            return countries;
        }
        #endregion

        #region State Select By CountryID
        public StateDropDownModel StateSelectByCountyID(int id)
        {
            StateDropDownModel state = new StateDropDownModel();
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_State_SelectComboBoxByCountryID";
            cmd.Parameters.AddWithValue("@CountryID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                state.StateID = Convert.ToInt32(reader["StateID"]);
                state.StateName = reader["StateName"].ToString().Trim();
            }
            return state;
        }
        #endregion
    }
}
