using CasinoCounterSystem.Model;
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
    }
}
