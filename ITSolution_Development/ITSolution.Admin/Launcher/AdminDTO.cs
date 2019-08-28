using ITSolution.Framework.Common.BaseClasses.CommonEntities;
using ITSolution.Framework.Entities;

namespace ITSolution.Admin.Launcher
{
    public class AdminDTO : AbstractUser
    {
        public AdminDTO(string nomeUtil, string senha, bool isAdmin = false) : base("", nomeUtil, senha)
        {
            _isAdmin = isAdmin;
        }

        bool _isAdmin = false;
        public bool IsAdmin
        {
            get
            {
                //if (string.IsNullOrWhiteSpace(NomeUtilizador) || string.IsNullOrWhiteSpace(Senha))
                //    return false;

                //return this.NomeUtilizador.Equals("admin") && this.Senha.Equals("a123")
                //       || this.NomeUtilizador.Equals("1") && this.Senha.Equals("a123");

                return _isAdmin;
            }
            private set
            {
                _isAdmin = value;
            }
        }
    }
}
