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

        /// <summary>
        /// Autentica un usuario con username y password
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns>Usuario autenticado o null si falla</returns>
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

                            // Por simplicidad, comparamos directamente (en producción deberías usar hash)
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

        /// <summary>
        /// Verifica si el usuario tiene un rol específico
        /// </summary>
        /// <param name="user">Usuario a verificar</param>
        /// <param name="roleName">Nombre del rol</param>
        /// <returns>True si tiene el rol</returns>
        public bool HasRole(User user, string roleName)
        {
            return user?.Role?.RoleName?.Equals(roleName, StringComparison.OrdinalIgnoreCase) == true;
        }

        /// <summary>
        /// Verifica si el usuario es administrador
        /// </summary>
        /// <param name="user">Usuario a verificar</param>
        /// <returns>True si es admin</returns>
        public bool IsAdmin(User user)
        {
            return HasRole(user, "Admin");
        }

        /// <summary>
        /// Verifica si el usuario es operador
        /// </summary>
        /// <param name="user">Usuario a verificar</param>
        /// <returns>True si es operador</returns>
        public bool IsOperator(User user)
        {
            return HasRole(user, "Counter Operator");
        }
    }
}
