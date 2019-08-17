using System;
using ITSolution.Admin.Enumeradores;

namespace ITSolution.Admin.Entidades.EntidadesBd
{
    /// <summary>
    /// Casca
    /// </summary>
    public class PackageDTO
    {

        public int IdPacote { get; set; }

        public string NumeroPacote { get; set; }
        public string Descricao { get; set; }
        public string Sintoma { get; set; }
        public string Tratamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public Nullable<DateTime> DataPublicacao { get; set; }

        public TypeStatusPackage Status { get; set; }

        public PackageDTO()
        {
        }

        public void Update(Package novo)
        {
            this.NumeroPacote = novo.NumeroPacote;
            this.DataCriacao = novo.DataCriacao;
            this.Descricao = novo.Descricao;

            this.Sintoma = novo.Sintoma;
            this.Tratamento = novo.Tratamento;
            this.DataPublicacao = novo.DataPublicacao;

            this.Status = novo.Status;


        }
    }
}
