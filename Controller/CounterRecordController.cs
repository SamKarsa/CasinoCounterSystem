using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CasinoCounterSystem.Controller
{
    public class CounterRecordController
    {
        private readonly DatabaseConnection dbConnection;

        public CounterRecordController()
        {
            dbConnection = new DatabaseConnection();
        }

        private static DateTime ParseDate(object? value)
        {
            // recordDate se guarda como TEXT 'YYYY-MM-DD'
            var s = value?.ToString() ?? "";
            if (DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out var dt))
                return dt;

            // fallback si alguna vez guardas 'yyyy-MM-ddTHH:mm:ss'
            if (DateTime.TryParse(s, out dt)) return dt;
            return DateTime.MinValue;
        }

        private static string ToIsoDate(DateTime dt) => dt.ToString("yyyy-MM-dd");

        #region CRUD
        public List<CounterRecord> GetAllCounterRecords()
        {
            var records = new List<CounterRecord>();

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return records;

                const string query = @"
                    SELECT counterRecordId, recordDate, counterIn, counterOut, totalDelivered, machineId
                    FROM CounterRecord
                    ORDER BY recordDate DESC";

                using (var cmd = new SqliteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new CounterRecord
                        {
                            CounterRecordId = Convert.ToInt32(reader["counterRecordId"]),
                            RecordDate = ParseDate(reader["recordDate"]),
                            CounterIn = Convert.ToInt64(reader["counterIn"]),
                            CounterOut = Convert.ToInt64(reader["counterOut"]),
                            // SQLite REAL -> double; Convert.ToDecimal maneja bien
                            TotalDelivered = Convert.ToDecimal(reader["totalDelivered"]),
                            MachineId = Convert.ToInt32(reader["machineId"])
                        });
                    }
                }
            }

            return records;
        }

        public CounterRecord? GetCounterRecordById(int id)
        {
            CounterRecord? record = null;

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return null;

                const string query = @"
                    SELECT counterRecordId, recordDate, counterIn, counterOut, totalDelivered, machineId
                    FROM CounterRecord
                    WHERE counterRecordId = @id";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            record = new CounterRecord
                            {
                                CounterRecordId = Convert.ToInt32(reader["counterRecordId"]),
                                RecordDate = ParseDate(reader["recordDate"]),
                                CounterIn = Convert.ToInt64(reader["counterIn"]),
                                CounterOut = Convert.ToInt64(reader["counterOut"]),
                                TotalDelivered = Convert.ToDecimal(reader["totalDelivered"]),
                                MachineId = Convert.ToInt32(reader["machineId"])
                            };
                        }
                    }
                }
            }

            return record;
        }

        public int InsertCounterRecord(CounterRecord record)
        {
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return 0;

                const string query = @"
                    INSERT INTO CounterRecord (recordDate, counterIn, counterOut, totalDelivered, machineId)
                    VALUES (@recordDate, @counterIn, @counterOut, @totalDelivered, @machineId);
                    SELECT last_insert_rowid();";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    // Guardamos fecha como TEXT ISO 'YYYY-MM-DD'
                    cmd.Parameters.AddWithValue("@recordDate", ToIsoDate(record.RecordDate));
                    cmd.Parameters.AddWithValue("@counterIn", record.CounterIn);
                    cmd.Parameters.AddWithValue("@counterOut", record.CounterOut);
                    cmd.Parameters.AddWithValue("@totalDelivered", record.TotalDelivered);
                    cmd.Parameters.AddWithValue("@machineId", record.MachineId);

                    var newId = (long)cmd.ExecuteScalar(); // SQLite devuelve long
                    return (int)newId;
                }
            }
        }

        public bool UpdateCounterRecord(CounterRecord record)
        {
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                const string query = @"
                    UPDATE CounterRecord
                    SET recordDate = @recordDate,
                        counterIn = @counterIn,
                        counterOut = @counterOut,
                        totalDelivered = @totalDelivered,
                        machineId = @machineId
                    WHERE counterRecordId = @id";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@recordDate", ToIsoDate(record.RecordDate));
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
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                const string query = "DELETE FROM CounterRecord WHERE counterRecordId = @id";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        #endregion

        public List<CounterRecord> GetCounterRecordsByMachine(int machineId)
        {
            var records = new List<CounterRecord>();

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return records;

                const string query = @"
                    SELECT counterRecordId, recordDate, counterIn, counterOut, totalDelivered, machineId
                    FROM CounterRecord
                    WHERE machineId = @machineId
                    ORDER BY recordDate";

                using (var cmd = new SqliteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@machineId", machineId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new CounterRecord
                            {
                                CounterRecordId = Convert.ToInt32(reader["counterRecordId"]),
                                RecordDate = ParseDate(reader["recordDate"]),
                                CounterIn = Convert.ToInt64(reader["counterIn"]),
                                CounterOut = Convert.ToInt64(reader["counterOut"]),
                                TotalDelivered = Convert.ToDecimal(reader["totalDelivered"]),
                                MachineId = Convert.ToInt32(reader["machineId"])
                            });
                        }
                    }
                }
            }

            return records;
        }

        public int CountByMachine(int machineId)
        {
            using (var cn = dbConnection.OpenConnection())
            {
                if (cn == null) return 0;
                using (var cmd = new SqliteCommand("SELECT COUNT(*) FROM CounterRecord WHERE machineId = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", machineId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool DeleteAllByMachine(int machineId)
        {
            using (var cn = dbConnection.OpenConnection())
            {
                if (cn == null) return false;
                using (var cmd = new SqliteCommand("DELETE FROM CounterRecord WHERE machineId = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", machineId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
