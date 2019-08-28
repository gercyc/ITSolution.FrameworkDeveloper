using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Common.BaseClasses.CommonEntities
{
    [Serializable]
    public class AbstractUser
    {

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "Nome Usuário")]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Nome Acesso")]
        public string NomeUtilizador { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Confirmação")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem!")]
        public string ConfirmarSenha { get; set; }

        [Required]
        [Display(Name = "Data Inclusão")]
        public DateTime DataInclusao { get; set; }

        [StringLength(200)]
        public string Skin { get; set; }

        public AbstractUser()
        {
        }

        public AbstractUser(string nomeUsuario, string nomeUtil, string senha )
        {
            //: Complete member initialization
            this.NomeUsuario = nomeUsuario;
            this.NomeUtilizador = nomeUtil;
            this.Senha = senha;
            this.DataInclusao = DateTime.Now;
        }


        public virtual void Update(AbstractUser current)
        {
            this.NomeUsuario = current.NomeUsuario;
            this.NomeUtilizador = current.NomeUtilizador;
            this.Senha = current.Senha;
            this.ConfirmarSenha = current.ConfirmarSenha;
        }

        public override string ToString()
        {
            return NomeUsuario;
        }

    }
}
