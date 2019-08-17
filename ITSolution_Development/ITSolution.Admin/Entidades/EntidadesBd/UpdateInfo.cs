using ITSolution.Admin.Entidades.DaoManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Admin.Entidades.EntidadesBd
{
    /// <summary>
    /// Classe que ira armazenar a informação de que o pacote XYZ foi instalado no banco do cliente.
    /// </summary>
    [Table("ITS_UPDATE_INFO")]
    public class UpdateInfo
    {

        [Key]
        public string IdUpdate { get; set; }

        public string NumeroPacote { get; set; }
        public string DescricaoUpdate { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string LogAplicacao { get; set; }
        public TypeStatusUpdate Status { get; set; }
        public UpdateInfo()
        {
            if(IdUpdate == null)
            {
                this.IdUpdate = newGuidID();
            }
        }

        public UpdateInfo(Package pacote, string log, TypeStatusUpdate status):this()
        {
            this.DataAplicacao = DateTime.Now;
            this.DescricaoUpdate = pacote.Descricao;
            this.NumeroPacote = pacote.NumeroPacote;
            this.LogAplicacao = log;
            this.Status = status;
        }

        public void Update(UpdateInfo updateInfo)
        {
            this.LogAplicacao = updateInfo.LogAplicacao;
            this.Status = updateInfo.Status;
            this.DataAplicacao = DateTime.Now;
        }
        private string newGuidID()
        {
            return "{" + Guid.NewGuid().ToString() + "}";
        }
    }
}
