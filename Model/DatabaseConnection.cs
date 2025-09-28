using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CasinoCounterSystem.Model
{
    internal class DatabaseConnection
    {
        private SqliteConnection? _connection;

        private string GetDbPath()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var dataDir = Path.Combine(baseDir, "Data");
            Directory.CreateDirectory(dataDir); // crea Data si no existe
            return Path.Combine(dataDir, "casino.db");
        }

        private bool TableExists(SqliteConnection cn, string name)
        {
            using var cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=@t LIMIT 1;";
            cmd.Parameters.AddWithValue("@t", name);
            return cmd.ExecuteScalar() != null;
        }

        /// <summary>
        /// Abre conexión SQLite. Si es primera vez o falta el esquema, lo crea.
        /// </summary>
        public SqliteConnection OpenConnection()
        {
            try
            {
                var dbPath = GetDbPath();
                var cs = GetConnectionString(dbPath);
                var firstTime = !File.Exists(dbPath);

                _connection = new SqliteConnection(cs);
                _connection.Open();

                // PRAGMAs recomendados
                using (var pragma = _connection.CreateCommand())
                {
                    pragma.CommandText =
                        "PRAGMA foreign_keys=ON; PRAGMA journal_mode=WAL; PRAGMA synchronous=NORMAL;";
                    pragma.ExecuteNonQuery();
                }

                // Ejecuta el schema en la 1ª vez o si falta la tabla clave
                if (firstTime || !TableExists(_connection, "Users"))
                {
                    EnsureSchema(_connection);
                }

                return _connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error abriendo SQLite: " + ex.Message);
                return null!;
            }
        }

        private string GetConnectionString(string dbPath)
        {
            // Asegúrate que el nombre coincida con app.config
            var fromConfig = ConfigurationManager.ConnectionStrings["CasinoCounter_DB_Sqlite"]?.ConnectionString;
            if (!string.IsNullOrWhiteSpace(fromConfig)) return fromConfig;

            // Fallback absoluto
            return $"Data Source={dbPath};Cache=Shared;Pooling=True;";
        }

        private void EnsureSchema(SqliteConnection cn)
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var schemaPath = Path.Combine(baseDir, "Schema", "schema_sqlite.sql");

                if (!File.Exists(schemaPath))
                    throw new FileNotFoundException($"No se encontró el schema en: {schemaPath}");

                using var cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(schemaPath);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando esquema SQLite: " + ex.Message);
                throw;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
    }
}
