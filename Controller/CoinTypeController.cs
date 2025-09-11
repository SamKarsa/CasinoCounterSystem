using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class CoinTypeController
    {
        private DatabaseConnection dbConnection;

        public CoinTypeController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<CoinType> GetAllCoins()
        {
            List<CoinType> coins = new List<CoinType>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return coins;

                string query = "SELECT coinTypeId, numCoin FROM CoinType ORDER BY numCoin";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coins.Add(new CoinType
                        {
                            CoinTypeId = (int)reader["coinTypeId"],
                            NumCoin = (int)reader["numCoin"]
                        });
                    }
                }
            }

            return coins;
        }
        #endregion
    }
}
