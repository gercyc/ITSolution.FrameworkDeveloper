using System;

namespace ITSolution.Framework.Listeners
{
    /// <summary>
    /// Ação abstrata para realzar Login na tela de XFrmLogin
    /// </summary>
    public interface ActionLogin
    {
        bool Login(string logon, string senha);
    }
}
