using System;

namespace ITSolution.Admin.Launcher
{
    static class Lancador
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new AdminMenuUtil().Run("1");
        }
    }

}
