using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoCounterSystem.Model;

namespace CasinoCounterSystem.Controller
{

    public static class SessionManager
    {
        private static User? _currentUser;

        public static bool IsAdmin => _currentUser?.Role?.RoleName == "Admin";

        public static int UserId => _currentUser?.UserId ?? 0;

        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public static void Logout()
        {
            _currentUser = null;
        }

    }
}
