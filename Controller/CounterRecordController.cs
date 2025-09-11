using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class CounterRecordController
    {
        private DatabaseConnection dbConnection;

        public CounterRecordController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD

        #endregion

        public bool InsertInitialRecord(int machineId, int counterIn, int counterOut)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = @"
                    INSERT INTO CounterRecord (recordDate, counterIn, counterOut, totalDelivered, machineId)
                    VALUES (GETDATE(), @counterIn, @counterOut, 0, @machineId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@machineId", machineId);
                    command.Parameters.AddWithValue("@counterIn", counterIn);
                    command.Parameters.AddWithValue("@counterOut", counterOut);

                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}
