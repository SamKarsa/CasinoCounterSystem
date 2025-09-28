using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;

namespace CasinoCounterSystem.Controller
{
    public class AuthController
    {
        private readonly DatabaseConnection dbConnection;

        public AuthController()
        {
            dbConnection = new DatabaseConnection();
        }

        public User? AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // DatabaseConnection.OpenConnection() debe devolver SqliteConnection abierto
            var connection = dbConnection.OpenConnection();
            if (connection == null) return null;

            try
            {
                const string query = @"
                    SELECT u.userId, u.userName, u.userPassword, u.userStatus, u.roleId, r.roleName 
                    FROM Users u 
                    INNER JOIN Role r ON u.roleId = r.roleId 
                    WHERE u.userName = @username AND u.userStatus = 1";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // En tu semilla la contraseña está en texto plano (luego podemos hashearla)
                            var storedPassword = reader["userPassword"]?.ToString() ?? string.Empty;

                            if (password == storedPassword)
                            {
                                var user = new User
                                {
                                    UserId = Convert.ToInt32(reader["userId"]),
                                    UserName = reader["userName"]?.ToString() ?? string.Empty,
                                    UserPassword = storedPassword,
                                    // En SQLite guardamos 0/1 -> conviene convertir a int y comparar
                                    UserStatus = Convert.ToInt32(reader["userStatus"]) == 1,
                                    RoleId = Convert.ToInt32(reader["roleId"]),
                                    Role = new Role
                                    {
                                        RoleId = Convert.ToInt32(reader["roleId"]),
                                        RoleName = reader["roleName"]?.ToString() ?? string.Empty
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
