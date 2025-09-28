using CasinoCounterSystem.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace CasinoCounterSystem.Controller
{
    public class RouteController
    {
        private readonly DatabaseConnection dbConnection;

        public RouteController()
        {
            dbConnection = new DatabaseConnection();
        }

        #region CRUD
        public List<Route> GetAllRoutes()
        {
            var routes = new List<Route>();

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return routes;

                const string query = "SELECT routeId, routeName FROM Route ORDER BY routeName";

                using (var command = new SqliteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        routes.Add(new Route
                        {
                            RouteId = Convert.ToInt32(reader["routeId"]),
                            RouteName = reader["routeName"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return routes;
        }

        public Route? GetRouteById(int routeId)
        {
            Route? route = null;

            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return route;

                const string query = "SELECT routeId, routeName FROM Route WHERE routeId = @routeId";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            route = new Route
                            {
                                RouteId = Convert.ToInt32(reader["routeId"]),
                                RouteName = reader["routeName"]?.ToString() ?? string.Empty
                            };
                        }
                    }
                }
            }

            return route;
        }

        public bool InsertRoute(string routeName)
        {
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                const string query = "INSERT INTO Route (routeName) VALUES (@routeName)";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeName", routeName);
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool UpdateRoute(int routeId, string routeName)
        {
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                const string query = "UPDATE Route SET routeName = @routeName WHERE routeId = @routeId";

                using (var command = new SqliteCommand(query, connection))
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
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                const string query = "DELETE FROM Route WHERE routeId = @routeId";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeId", routeId);
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        #endregion

        public bool RouteNameExists(string routeName, bool caseInsensitive = false)
        {
            using (SqliteConnection connection = dbConnection.OpenConnection())
            {
                if (connection == null) return false;

                string query = caseInsensitive
                    ? "SELECT 1 FROM Route WHERE routeName = @routeName COLLATE NOCASE LIMIT 1"
                    : "SELECT 1 FROM Route WHERE routeName = @routeName LIMIT 1";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@routeName", routeName);
                    var result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }
    }
}
