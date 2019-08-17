using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITSolution.Admin.Enumeradores;

namespace ITSolution.Admin.Entidades.EntidadesBd
{
    /// <summary>
    /// Classe do pacote de atualização. Este pacote irá conter os scripts de banco que deverão ser executados
    /// no em cada cliente. 
    /// </summary>
    [Table("ITS_PACKAGE")]
    [Serializable]
    public class Package
    {

        [Key]//pk
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPacote { get; set; }

        public string NumeroPacote { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "Informe a \"Descrição\" do pacote, minímo 5 caracteres")]
        public string Descricao { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "Informe o \"Sintoma\" do problema, minímo 5 caracteres")]
        public string Sintoma { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "Informe os \"Tratamentos\" realizados, minímo 5 caracteres")]
        public string Tratamento { get; set; }

        public DateTime DataCriacao { get; set; }

        public Nullable<DateTime> DataPublicacao { get; set; }

        public virtual ICollection<AnexoPackage> Anexos { get; set; }

        public int CountPackages { get { return this.Anexos.Count; } }
        public byte[] ArquivoFinal { get; set; }

        //ainda nao implementado
        //[ForeignKey("IdAdmin")]
        //public virtual Administrator Administrator { get; set; }
        //public int IdAdmin { get; set; }

        public TypeStatusPackage Status { get; set; }

        public Package()
        {
            this.Anexos = new HashSet<AnexoPackage>();
        }

        public Package(string numero, DateTime dtCriacao, string descricao, string sintoma, string tratamento, List<AnexoPackage> anexos, Nullable<DateTime> dtPublicacao)
        {
            this.Anexos = new HashSet<AnexoPackage>();
            this.NumeroPacote = numero;
            this.DataCriacao = dtCriacao;
            this.Descricao = descricao;
            this.Sintoma = sintoma;
            this.Tratamento = tratamento;
            this.DataPublicacao = dtPublicacao;
            this.Status = TypeStatusPackage.Criado;

            foreach (var anexo in anexos)
            {
                this.Anexos.Add(anexo);
            }

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
        public void Publish(DateTime dtPublicacao, byte[] arquivoFinal)
        {
            this.DataPublicacao = dtPublicacao;
            this.Status = TypeStatusPackage.Publicado;
            this.ArquivoFinal = arquivoFinal;
        }

        public override string ToString()
        {
            return "Package_" + this.NumeroPacote;
        }
    }
}
