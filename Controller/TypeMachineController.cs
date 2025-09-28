using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace CasinoCounterSystem.Controller
{
    public class TypeMachineController
    {
        private readonly DatabaseConnection dbConnection;

        public TypeMachineController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<TypeMachine> GetAllTypeMachine()
        {
            var types = new List<TypeMachine>();

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return types;

                const string query = "SELECT typeMachineId, nameTypeMachine FROM TypeMachine ORDER BY nameTypeMachine";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(new TypeMachine
                        {
                            TypeMachineId = Convert.ToInt32(reader["typeMachineId"]),
                            NameTypeMachine = reader["nameTypeMachine"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return types;
        }
        #endregion
    }
}
