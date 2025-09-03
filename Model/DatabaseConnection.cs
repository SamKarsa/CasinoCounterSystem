using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace CasinoCounterSystem.Model
{
    internal class DatabaseConnection
    {
        private SqlConnection? _Connection;

        public SqlConnection OpenConnection()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["CasinoCounter_DB"].ConnectionString;


            _Connection = new SqlConnection(connectionString);


            try
            {
                _Connection.Open();
                return _Connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null!;
            }
        }

        public void CloseConnection()
        {
            if (_Connection != null && _Connection.State == System.Data.ConnectionState.Open) _Connection.Close();
        }
    }
}
