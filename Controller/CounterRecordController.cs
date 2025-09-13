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
        public List<CounterRecord> GetAllCounterRecords()
        {
            List<CounterRecord> records = new List<CounterRecord>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return records;

                string query = @"
                    SELECT counterRecordId, recordDate, counterIn, counterOut, totalDelivered, machineId
                    FROM CounterRecord
                    ORDER BY recordDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new CounterRecord
                        {
                            CounterRecordId = (int)reader["counterRecordId"],
                            RecordDate = (DateTime)reader["recordDate"],
                            CounterIn = (long)reader["counterIn"],
                            CounterOut = (long)reader["counterOut"],
                            TotalDelivered = (decimal)reader["totalDelivered"],
                            MachineId = (int)reader["machineId"]
                        });
                    }
                }
            }

            return records;
        }

        public CounterRecord? GetCounterRecordById(int id)
        {
            CounterRecord? record = null;

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return null;

                string query = @"
                    SELECT counterRecordId, recordDate, counterIn, counterOut, totalDelivered, machineId
                    FROM CounterRecord
                    WHERE counterRecordId = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            record = new CounterRecord
                            {
                                CounterRecordId = (int)reader["counterRecordId"],
                                RecordDate = (DateTime)reader["recordDate"],
                                CounterIn = (long)reader["counterIn"],
                                CounterOut = (long)reader["counterOut"],
                                TotalDelivered = (decimal)reader["totalDelivered"],
                                MachineId = (int)reader["machineId"]
                            };
                        }
                    }
                }
            }

            return record;
        }

        public int InsertCounterRecord(CounterRecord record)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return 0;

                string query = @"
                    INSERT INTO CounterRecord (recordDate, counterIn, counterOut, totalDelivered, machineId)
                    VALUES (@recordDate, @counterIn, @counterOut, @totalDelivered, @machineId);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@recordDate", record.RecordDate);
                    cmd.Parameters.AddWithValue("@counterIn", record.CounterIn);
                    cmd.Parameters.AddWithValue("@counterOut", record.CounterOut);
                    cmd.Parameters.AddWithValue("@totalDelivered", record.TotalDelivered);
                    cmd.Parameters.AddWithValue("@machineId", record.MachineId);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateCounterRecord(CounterRecord record)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = @"
                    UPDATE CounterRecord
                    SET recordDate = @recordDate,
                        counterIn = @counterIn,
                        counterOut = @counterOut,
                        totalDelivered = @totalDelivered,
                        machineId = @machineId
                    WHERE counterRecordId = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@recordDate", record.RecordDate);
                    cmd.Parameters.AddWithValue("@counterIn", record.CounterIn);
                    cmd.Parameters.AddWithValue("@counterOut", record.CounterOut);
                    cmd.Parameters.AddWithValue("@totalDelivered", record.TotalDelivered);
                    cmd.Parameters.AddWithValue("@machineId", record.MachineId);
                    cmd.Parameters.AddWithValue("@id", record.CounterRecordId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool DeleteCounterRecord(int id)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = "DELETE FROM CounterRecord WHERE counterRecordId = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        #endregion
    }
}
