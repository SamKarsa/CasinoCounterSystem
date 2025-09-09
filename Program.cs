using CasinoCounterSystem.View;

namespace CasinoCounterSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // CONFIGURACIÓN PARA RESOLVER PROBLEMAS DE DPI/ESCALADO

            // Configurar DPI Awareness para Windows 10/11
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            // Configuraciones de aplicación modernas
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Configurar escalado automático
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            Application.Run(new MainForm());
        }

        // Importar función de Windows API para DPI
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}