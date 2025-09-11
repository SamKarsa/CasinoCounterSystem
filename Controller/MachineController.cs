using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class MachineController
    {
        private DatabaseConnection dbConnection;

        public MachineController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<Machine> GetAllMachines()
        {
            List<Machine> machines = new List<Machine>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return machines;

                string query = @"
                    SELECT m.machineId, m.numberMachine, m.typeMachineId, m.coinTypeId, m.routeId,
                           i.nameClient, i.phone, i.address
                    FROM Machine m
                    LEFT JOIN InfoMachine i ON m.machineId = i.infoMachineId
                    ORDER BY m.numberMachine";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        machines.Add(new Machine
                        {
                            MachineId = (int)reader["machineId"],
                            NumberMachine = (string)reader["numberMachine"],
                            TypeMachineId = (int)reader["typeMachineId"],
                            CoinTypeId = (int)reader["coinTypeId"],
                            RouteId = (int)reader["routeId"],
                            InfoMachine = reader["nameClient"] == DBNull.Value ? null : new InfoMachine
                            {
                                InfoMachineId = (int)reader["machineId"],
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

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return null;

                string query = @"
                    SELECT m.machineId, m.numberMachine, m.typeMachineId, m.coinTypeId, m.routeId,
                           i.nameClient, i.phone, i.address
                    FROM Machine m
                    LEFT JOIN InfoMachine i ON m.machineId = i.infoMachineId
                    WHERE m.machineId = @machineId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@machineId", machineId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            machine = new Machine
                            {
                                MachineId = (int)reader["machineId"],
                                NumberMachine = (string)reader["numberMachine"],
                                TypeMachineId = (int)reader["typeMachineId"],
                                CoinTypeId = (int)reader["coinTypeId"],
                                RouteId = (int)reader["routeId"],
                                InfoMachine = reader["nameClient"] == DBNull.Value ? null : new InfoMachine
                                {
                                    InfoMachineId = (int)reader["machineId"],
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

        public int InsertMachine(Machine machine)
        {
            int newMachineId = 0;

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return 0;

                string insertMachine = @"
                    INSERT INTO Machine (numberMachine, typeMachineId, coinTypeId, routeId)
                    VALUES (@numberMachine, @typeMachineId, @coinTypeId, @routeId);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(insertMachine, connection))
                {
                    command.Parameters.AddWithValue("@numberMachine", machine.NumberMachine);
                    command.Parameters.AddWithValue("@typeMachineId", machine.TypeMachineId);
                    command.Parameters.AddWithValue("@coinTypeId", machine.CoinTypeId);
                    command.Parameters.AddWithValue("@routeId", machine.RouteId);

                    newMachineId = Convert.ToInt32(command.ExecuteScalar());
                }

                if (machine.InfoMachine != null)
                {
                    string insertInfo = @"
                        INSERT INTO InfoMachine (infoMachineId, nameClient, phone, address)
                        VALUES (@infoMachineId, @nameClient, @phone, @address)";

                    using (SqlCommand command = new SqlCommand(insertInfo, connection))
                    {
                        command.Parameters.AddWithValue("@infoMachineId", newMachineId);
                        command.Parameters.AddWithValue("@nameClient", (object)machine.InfoMachine.NameClient ?? DBNull.Value);
                        command.Parameters.AddWithValue("@phone", (object)machine.InfoMachine.Phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@address", (object)machine.InfoMachine.Address ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }

            return newMachineId;
        }

        public bool UpdateMachine(Machine machine)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string updateMachine = @"
                    UPDATE Machine
                    SET numberMachine = @numberMachine,
                        typeMachineId = @typeMachineId,
                        coinTypeId = @coinTypeId,
                        routeId = @routeId
                    WHERE machineId = @machineId";

                using (SqlCommand command = new SqlCommand(updateMachine, connection))
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
                    string updateInfo = @"
                        IF EXISTS (SELECT 1 FROM InfoMachine WHERE infoMachineId = @infoMachineId)
                            UPDATE InfoMachine
                            SET nameClient = @nameClient,
                                phone = @phone,
                                address = @address
                            WHERE infoMachineId = @infoMachineId
                        ELSE
                            INSERT INTO InfoMachine (infoMachineId, nameClient, phone, address)
                            VALUES (@infoMachineId, @nameClient, @phone, @address)";

                    using (SqlCommand command = new SqlCommand(updateInfo, connection))
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
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string deleteInfo = "DELETE FROM InfoMachine WHERE infoMachineId = @machineId";
                using (SqlCommand cmd = new SqlCommand(deleteInfo, connection))
                {
                    cmd.Parameters.AddWithValue("@machineId", machineId);
                    cmd.ExecuteNonQuery();
                }

                string deleteMachine = "DELETE FROM Machine WHERE machineId = @machineId";
                using (SqlCommand cmd = new SqlCommand(deleteMachine, connection))
                {
                    cmd.Parameters.AddWithValue("@machineId", machineId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        #endregion
    }
}
