using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoCounterSystem.Model;

namespace CasinoCounterSystem.Controller
{
    /// <summary>
    /// Maneja la sesión del usuario actual en la aplicación
    /// </summary>
    public static class SessionManager
    {
        private static User? _currentUser;

        /// <summary>
        /// Usuario actualmente logueado
        /// </summary>
        public static User? CurrentUser
        {
            get => _currentUser;
            private set => _currentUser = value;
        }


        /// <summary>
        /// Indica si hay un usuario logueado
        /// </summary>
        public static bool IsLoggedIn => _currentUser != null;


        /// <summary>
        /// Indica si el usuario actual es administrador
        /// </summary>
        public static bool IsAdmin => _currentUser?.Role?.RoleName == "Admin";

        /// <summary>
        /// Indica si el usuario actual es operador
        /// </summary>
        public static bool IsOperator => _currentUser?.Role?.RoleName == "Counter Operator";

        /// <summary>
        /// Establece el usuario actual en la sesión
        /// </summary>
        /// <param name="user">Usuario a establecer</param>
        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        /// <summary>
        /// Cierra la sesión del usuario actual
        /// </summary>
        public static void Logout()
        {
            _currentUser = null;
        }

        /// <summary>
        /// Obtiene el nombre del usuario actual
        /// </summary>
        /// <returns>Nombre del usuario o cadena vacía si no está logueado</returns>
        public static string GetCurrentUserName()
        {
            return _currentUser?.UserName ?? string.Empty;
        }

        /// <summary>
        /// Obtiene el rol del usuario actual
        /// </summary>
        /// <returns>Nombre del rol o cadena vacía si no está logueado</returns>
        public static string GetCurrentUserRole()
        {
            return _currentUser?.Role?.RoleName ?? string.Empty;
        }
    }
}
