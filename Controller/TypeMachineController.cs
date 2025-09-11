using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class TypeMachineController
    {
        private DatabaseConnection dbConnection;

        public TypeMachineController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<TypeMachine> GetAllTypeMachine()
        {
            List<TypeMachine> types = new List<TypeMachine>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return types;

                string query = "SELECT typeMachineId, nameTypeMachine FROM TypeMachine ORDER BY nameTypeMachine";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(new TypeMachine
                        {
                            TypeMachineId = (int)reader["typeMachineId"],
                            NameTypeMachine = reader["nameTypeMachine"].ToString()!
                        });
                    }
                }
            }

            return types;
        }
        #endregion
    }
}
