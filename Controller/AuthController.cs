using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace CasinoCounterSystem.Controller
{
    public class AuthController
    {
        private readonly DatabaseConnection dbConnection;

        public AuthController()
        {
            dbConnection = new DatabaseConnection();
        }

        private static bool VerifyMasterKey(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            var expected = ConfigurationManager.AppSettings["MasterKeyHash"];
            if (string.IsNullOrEmpty(expected)) return false;

            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            var b64 = Convert.ToBase64String(bytes);

            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(b64),
                Encoding.UTF8.GetBytes(expected)
            );
        }

        public User? AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var connection = dbConnection.OpenConnection();
            if (connection == null) return null;

            try
            {
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && VerifyMasterKey(password))
                {
                    var defaultAdminPwd = ConfigurationManager.AppSettings["AdminDefaultPassword"] ?? "Admin123";

                    using (var upd = connection.CreateCommand())
                    {
                        upd.CommandText = @"UPDATE Users SET userPassword=@p WHERE LOWER(userName)='admin';";
                        upd.Parameters.AddWithValue("@p", defaultAdminPwd);
                        upd.ExecuteNonQuery();
                    }

                    MessageBox.Show(
                        "Restaurando contraseña del administrador correctamente.\n\n" +
                        $"La contraseña temporal es: {defaultAdminPwd}",
                        "Restauración exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return null;
                }

                const string query = @"
                    SELECT u.userId, u.userName, u.userPassword, u.userStatus, u.roleId, r.roleName 
                    FROM Users u 
                    INNER JOIN Role r ON u.roleId = r.roleId 
                    WHERE u.userName = @username AND u.userStatus = 1
                    LIMIT 1";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@username", username);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedPassword = reader["userPassword"]?.ToString() ?? string.Empty;

                            if (password == storedPassword)
                            {
                                var user = new User
                                {
                                    UserId = Convert.ToInt32(reader["userId"]),
                                    UserName = reader["userName"]?.ToString() ?? string.Empty,
                                    UserPassword = storedPassword,
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
