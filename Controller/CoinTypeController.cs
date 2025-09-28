using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace CasinoCounterSystem.Controller
{
    public class CoinTypeController
    {
        private readonly DatabaseConnection dbConnection;

        public CoinTypeController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region Allcoins function
        public List<CoinType> GetAllCoins()
        {
            var coins = new List<CoinType>();

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return coins;

                string query = "SELECT coinTypeId, numCoin FROM CoinType ORDER BY numCoin";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coins.Add(new CoinType
                        {
                            CoinTypeId = Convert.ToInt32(reader["coinTypeId"]),
                            NumCoin = Convert.ToInt32(reader["numCoin"])
                        });
                    }
                }
            }

            return coins;
        }
        #endregion
    }
}
