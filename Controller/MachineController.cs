using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace CasinoCounterSystem.Controller
{
    public class MachineController
    {
        private readonly DatabaseConnection dbConnection;

        public MachineController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<Machine> GetAllMachines()
        {
            var machines = new List<Machine>();

            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return machines;

                string query = @"
                    SELECT m.machineId, m.numberMachine, m.typeMachineId, m.coinTypeId, m.routeId,
                           i.nameClient, i.phone, i.address
                    FROM Machine m
                    LEFT JOIN InfoMachine i ON m.machineId = i.infoMachineId
                    ORDER BY m.numberMachine";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        machines.Add(new Machine
                        {
                            MachineId = Convert.ToInt32(reader["machineId"]),
                            NumberMachine = reader["numberMachine"].ToString()!,
                            TypeMachineId = Convert.ToInt32(reader["typeMachineId"]),
                            CoinTypeId = Convert.ToInt32(reader["coinTypeId"]),
                            RouteId = Convert.ToInt32(reader["routeId"]),
                            InfoMachine = reader["nameClient"] == DBNull.Value ? null : new InfoMachine
                            {
                                InfoMachineId = Convert.ToInt32(reader["machineId"]),
                                NameClient = reader["nameClient"] as string,
                                Phone = reader["phone"] as string,
                                Address = reader["address"] as string
                            }
                        });
                    }
                }
            }

            return machines;
        }

        public Machine? GetMachineById(int machineId)
        {
            Machine? machine = null;

            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return null;

                string query = @"
                SELECT m.machineId, m.numberMachine, m.typeMachineId, m.coinTypeId, m.routeId,
                       tm.nameTypeMachine,
                       c.numCoin,
                       i.nameClient, i.phone, i.address
                FROM Machine m
                LEFT JOIN InfoMachine i ON m.machineId = i.infoMachineId
                LEFT JOIN TypeMachine tm ON m.typeMachineId = tm.typeMachineId
                LEFT JOIN CoinType c ON m.coinTypeId = c.coinTypeId
                WHERE m.machineId = @machineId";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@machineId", machineId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            machine = new Machine
                            {
                                MachineId = Convert.ToInt32(reader["machineId"]),
                                NumberMachine = reader["numberMachine"].ToString()!,
                                TypeMachineId = Convert.ToInt32(reader["typeMachineId"]),
                                CoinTypeId = Convert.ToInt32(reader["coinTypeId"]),
                                RouteId = Convert.ToInt32(reader["routeId"]),

                                TypeMachine = new TypeMachine
                                {
                                    TypeMachineId = Convert.ToInt32(reader["typeMachineId"]),
                                    NameTypeMachine = reader["nameTypeMachine"].ToString()!
                                },

                                CoinType = new CoinType
                                {
                                    CoinTypeId = Convert.ToInt32(reader["coinTypeId"]),
                                    NumCoin = Convert.ToInt32(reader["numCoin"])
                                },

                                InfoMachine = reader["nameClient"] == DBNull.Value ? null : new InfoMachine
                                {
                                    InfoMachineId = Convert.ToInt32(reader["machineId"]),
                                    NameClient = reader["nameClient"] as string,
                                    Phone = reader["phone"] as string,
                                    Address = reader["address"] as string
                                }
                            };
                        }
                    }
                }
            }

            return machine;
        }

        public int InsertMachine(Machine machine, int counterIn, int counterOut)
        {
            int newMachineId = 0;

            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return 0;

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar en Machine
                        string insertMachine = @"
                        INSERT INTO Machine (numberMachine, typeMachineId, coinTypeId, routeId)
                        VALUES (@numberMachine, @typeMachineId, @coinTypeId, @routeId);
                        SELECT last_insert_rowid();";

                        using (var command = new SqliteCommand(insertMachine, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@numberMachine", machine.NumberMachine);
                            command.Parameters.AddWithValue("@typeMachineId", machine.TypeMachineId);
                            command.Parameters.AddWithValue("@coinTypeId", machine.CoinTypeId);
                            command.Parameters.AddWithValue("@routeId", machine.RouteId);

                            newMachineId = Convert.ToInt32((long)command.ExecuteScalar());
                        }

                        // 2. Insertar en InfoMachine (obligatorio)
                        string insertInfo = @"
                        INSERT INTO InfoMachine (infoMachineId, nameClient, phone, address)
                        VALUES (@infoMachineId, @nameClient, @phone, @address)";

                        using (var command = new SqliteCommand(insertInfo, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@infoMachineId", newMachineId);
                            command.Parameters.AddWithValue("@nameClient", (object)machine.InfoMachine?.NameClient ?? DBNull.Value);
                            command.Parameters.AddWithValue("@phone", (object)machine.InfoMachine?.Phone ?? DBNull.Value);
                            command.Parameters.AddWithValue("@address", (object)machine.InfoMachine?.Address ?? DBNull.Value);

                            command.ExecuteNonQuery();
                        }

                        // 3. Insertar primer registro en CounterRecord
                        string insertCounter = @"
                        INSERT INTO CounterRecord (recordDate, counterIn, counterOut, totalDelivered, machineId)
                        VALUES (@initDate, @counterIn, @counterOut, 0, @machineId)";

                        using (var command = new SqliteCommand(insertCounter, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@machineId", newMachineId);
                            command.Parameters.AddWithValue("@counterIn", counterIn);
                            command.Parameters.AddWithValue("@counterOut", counterOut);
                            // Fecha fija, guardada como TEXT
                            command.Parameters.AddWithValue("@initDate", "2006-03-14");

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return newMachineId;
        }

        public bool UpdateMachine(Machine machine)
        {
            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string updateMachine = @"
                    UPDATE Machine
                    SET numberMachine = @numberMachine,
                        typeMachineId = @typeMachineId,
                        coinTypeId = @coinTypeId,
                        routeId = @routeId
                    WHERE machineId = @machineId";

                using (var command = new SqliteCommand(updateMachine, connection))
                {
                    command.Parameters.AddWithValue("@machineId", machine.MachineId);
                    command.Parameters.AddWithValue("@numberMachine", machine.NumberMachine);
                    command.Parameters.AddWithValue("@typeMachineId", machine.TypeMachineId);
                    command.Parameters.AddWithValue("@coinTypeId", machine.CoinTypeId);
                    command.Parameters.AddWithValue("@routeId", machine.RouteId);

                    command.ExecuteNonQuery();
                }

                if (machine.InfoMachine != null)
                {
                    // SQLite no soporta IF/ELSE, usamos INSERT OR REPLACE
                    string upsertInfo = @"
                        INSERT OR REPLACE INTO InfoMachine (infoMachineId, nameClient, phone, address)
                        VALUES (@infoMachineId, @nameClient, @phone, @address)";

                    using (var command = new SqliteCommand(upsertInfo, connection))
                    {
                        command.Parameters.AddWithValue("@infoMachineId", machine.MachineId);
                        command.Parameters.AddWithValue("@nameClient", (object)machine.InfoMachine.NameClient ?? DBNull.Value);
                        command.Parameters.AddWithValue("@phone", (object)machine.InfoMachine.Phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@address", (object)machine.InfoMachine.Address ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }

            return true;
        }

        public bool DeleteMachine(int machineId)
        {
            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string deleteInfo = "DELETE FROM InfoMachine WHERE infoMachineId = @machineId";
                using (var cmd = new SqliteCommand(deleteInfo, connection))
                {
                    cmd.Parameters.AddWithValue("@machineId", machineId);
                    cmd.ExecuteNonQuery();
                }

                string deleteMachine = "DELETE FROM Machine WHERE machineId = @machineId";
                using (var cmd = new SqliteCommand(deleteMachine, connection))
                {
                    cmd.Parameters.AddWithValue("@machineId", machineId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        #endregion

        public List<Machine> GetMachinesByRoute(int routeId)
        {
            var machines = new List<Machine>();

            using (var connection = dbConnection.OpenConnection())
            {
                if (connection == null) return machines;

                string query = @"
                SELECT m.machineId, m.numberMachine, m.typeMachineId, m.coinTypeId, m.routeId,
                       i.nameClient, i.phone, i.address
                FROM Machine m
                LEFT JOIN InfoMachine i ON m.machineId = i.infoMachineId
                WHERE m.routeId = @routeId
                ORDER BY m.numberMachine";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            machines.Add(new Machine
                            {
                                MachineId = Convert.ToInt32(reader["machineId"]),
                                NumberMachine = reader["numberMachine"].ToString()!,
                                TypeMachineId = Convert.ToInt32(reader["typeMachineId"]),
                                CoinTypeId = Convert.ToInt32(reader["coinTypeId"]),
                                RouteId = Convert.ToInt32(reader["routeId"]),
                                InfoMachine = reader["nameClient"] == DBNull.Value ? null : new InfoMachine
                                {
                                    InfoMachineId = Convert.ToInt32(reader["machineId"]),
                                    NameClient = reader["nameClient"] as string,
                                    Phone = reader["phone"] as string,
                                    Address = reader["address"] as string
                                }
                            });
                        }
                    }
                }
            }

            return machines;
        }
    }
}
