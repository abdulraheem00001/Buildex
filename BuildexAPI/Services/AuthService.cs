using BuildexAPI.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BuildexAPI.Services
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (bool Success, string Message) AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("AddUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", user.Password);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return (true, "User registered successfully");
                }
                catch (SqlException ex)
                {
                    return (false, ex.Message);
                }
            }
        }

        public (bool Success, string Message) Login(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("LoginUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", user.Password);

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return (true, "Login successful");
                    else
                        return (false, "Invalid email or password");
                }
                catch (SqlException ex)
                {
                    return (false, ex.Message);
                }
            }
        }
    }
}
