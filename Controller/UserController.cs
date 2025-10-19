using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class UserController
    {
        private readonly DatabaseConnection dbConnection;

        public UserController()
        {
            dbConnection = new DatabaseConnection();
        }

        public bool ChangeMyPassword(int userId, string currentPassword, string newPassword)
        {
            if (userId <= 0) return false;
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword)) return false;

            var cn = dbConnection.OpenConnection();
            if (cn == null) return false;

            try
            {
                // 1) Validar la actual
                using (var check = cn.CreateCommand())
                {
                    check.CommandText = @"SELECT userPassword FROM Users WHERE userId=@id AND userStatus=1;";
                    check.Parameters.AddWithValue("@id", userId);

                    var stored = check.ExecuteScalar()?.ToString() ?? "";
                    if (!string.Equals(stored, currentPassword, StringComparison.Ordinal))
                        return false; // actual incorrecta
                }

                // 2) Actualizar a la nueva
                using (var upd = cn.CreateCommand())
                {
                    upd.CommandText = @"UPDATE Users SET userPassword=@p WHERE userId=@id;";
                    upd.Parameters.AddWithValue("@p", newPassword);
                    upd.Parameters.AddWithValue("@id", userId);
                    return upd.ExecuteNonQuery() == 1;
                }
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        public bool AdminResetOperatorPassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword)) return false;

            var cn = dbConnection.OpenConnection();
            if (cn == null) return false;

            try
            {
                using var cmd = cn.CreateCommand();
                // Si preferís por roleId=2 en vez de userName, cambia el WHERE.
                cmd.CommandText = @"UPDATE Users SET userPassword=@p 
                                    WHERE userName='operator' AND userStatus=1;";
                cmd.Parameters.AddWithValue("@p", newPassword);
                return cmd.ExecuteNonQuery() == 1;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

    }
}
