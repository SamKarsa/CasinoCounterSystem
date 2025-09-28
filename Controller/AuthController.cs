using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class AuthController
    {
        private DatabaseConnection dbConnection;

        public AuthController()
        {
            dbConnection = new DatabaseConnection();
        }

        public User? AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            SqlConnection connection = dbConnection.OpenConnection();
            if (connection == null) return null;

            try
            {
                string query = @"
                    SELECT u.userId, u.userName, u.userPassword, u.userStatus, u.roleId, r.roleName 
                    FROM Users u 
                    INNER JOIN Role r ON u.roleId = r.roleId 
                    WHERE u.userName = @username AND u.userStatus = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["userPassword"].ToString()!;

                            
                            if (password == storedPassword)
                            {
                                User user = new User
                                {
                                    UserId = Convert.ToInt32(reader["userId"]),
                                    UserName = reader["userName"].ToString()!,
                                    UserPassword = reader["userPassword"].ToString()!,
                                    UserStatus = Convert.ToBoolean(reader["userStatus"]),
                                    RoleId = Convert.ToInt32(reader["roleId"]),
                                    Role = new Role
                                    {
                                        RoleId = Convert.ToInt32(reader["roleId"]),
                                        RoleName = reader["roleName"].ToString()!
                                    }
                                };

                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during authentication: {ex.Message}");
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return null;
        }
        
    }
}
