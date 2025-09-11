using CasinoCounterSystem.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Controller
{
    public class RouteController
    {
        private DatabaseConnection dbConnection;

        public RouteController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<Route> GetAllRoutes()
        {
            List<Route> routes = new List<Route>();

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return routes;

                string query = "SELECT routeId, routeName FROM Route ORDER BY routeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        routes.Add(new Route
                        {
                            RouteId = reader.GetInt32(reader.GetOrdinal("routeId")),
                            RouteName = reader.GetString(reader.GetOrdinal("routeName"))
                        });
                    }
                }
                dbConnection.CloseConnection();
            }

            return routes;
        }

        public Route GetRouteById(int routeId)
        {
            Route route = null;

            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return route;

                string query = "SELECT routeId, routeName FROM Route WHERE routeId = @routeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            route = new Route
                            {
                                RouteId = reader.GetInt32(reader.GetOrdinal("routeId")),
                                RouteName = reader.GetString(reader.GetOrdinal("routeName"))
                            };
                        }
                    }
                }
                dbConnection.CloseConnection();
            }

            return route;
        }

        public bool InsertRoute(string routeName)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = "INSERT INTO Route (routeName) VALUES (@routeName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeName", routeName);
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool UpdateRoute(int routeId, string routeName)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = "UPDATE Route SET routeName = @routeName WHERE routeId = @routeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);
                    command.Parameters.AddWithValue("@routeName", routeName);

                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool DeleteRoute(int routeId)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = "DELETE FROM Route WHERE routeId = @routeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        #endregion

        public bool RouteNameExists(string routeName)
        {
            using (SqlConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                // Si quieres case-insensitive aunque la collation lo suele ser:
                // SELECT 1 FROM Route WHERE LOWER(routeName) = LOWER(@routeName)
                string query = "SELECT 1 FROM Route WHERE routeName = @routeName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeName", routeName);
                    var result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }
    }
}
