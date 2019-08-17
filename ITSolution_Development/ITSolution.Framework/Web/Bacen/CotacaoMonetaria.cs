using ITSolution.Framework.WSBacen;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITSolution.Framework.Web.Bacen
{
    [Table("ITS_COTACAO_MONETARIA")]
    public class CotacaoMonetaria
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdCotacaoMonetaria { get; set; }

        [Display(Name = "Data Cotação")]
        public DateTime DataCotacao { get; set; }

        [Display(Name = "Valor Compra")]
        public decimal ValorCompra { get; set; }

        [Display(Name = "Valor Venda")]
        public decimal ValorVenda { get; set; }

        public int IdMoeda { get; set; }

        [ForeignKey("IdMoeda")]
        public virtual Moeda Moeda { get; set; }

        [StringLength(45, MinimumLength = 0)]
        public string Fonte { get; set; }   //PTAX

        [StringLength(100, MinimumLength = 0)]
        public string FullName { get; set; }    //Exchange rate - Free - Swiss Franc (bid)

        [StringLength(45, MinimumLength = 0)]
        public string GestorProprietario { get; set; }  //DEPEC/DIBAP/SUCAP

        [StringLength(45, MinimumLength = 0)]
        public string NomeAbreviado { get; set; }   //Franco Suíço (compra)

        [StringLength(100, MinimumLength = 0)]
        public string NomeCompleto { get; set; }    //Taxa de câmbio - Livre - Franco Suíço (compra)

        [StringLength(45, MinimumLength = 0)]
        public string Periodicidade { get; set; }  //Diária

        [StringLength(45, MinimumLength = 0)]
        public string ShortName { get; set; }   //Swiss Franc (bid)

        [StringLength(45, MinimumLength = 0)]
        public string UnidadePadrao { get; set; }	//R$/u.m.c.

        public CotacaoMonetaria()
        {
            this.DataCotacao = DateTime.Now;
        }
        public CotacaoMonetaria(decimal compra, decimal venda) : this()
        {
            this.ValorCompra = compra;
            this.ValorVenda = venda;
        }

        public CotacaoMonetaria(DateTime dataCotacao, decimal compra, decimal venda)
        {
            this.DataCotacao = dataCotacao;
            this.ValorCompra = compra;
            this.ValorVenda = venda;
        }

        public CotacaoMonetaria(DateTime dataCotacao, decimal compra, decimal venda, IndicadoresBacen ind)
            : this(dataCotacao, compra, venda)
        {

            var moeda = new Moeda();
            moeda.NomeMoeda = ind.NomeCompletoMoeda;
            moeda.CodigoWSCompra = ind.CodigoMoeda;

            this.Moeda = moeda;
            this.IdMoeda = ind.IdMoeda;
        }

        public CotacaoMonetaria(DateTime dataCotacao, decimal compra, decimal venda, WSSerieVO serie)
            : this(dataCotacao, compra, venda)
        {
            AddReference(serie);
        }

        public void AddReference(WSSerieVO serie)
        {
            this.Fonte = serie.fonte;

            this.NomeCompleto = serie.nomeCompleto;

            this.NomeAbreviado = serie.nomeAbreviado;

            this.GestorProprietario = serie.gestorProprietario;

            this.FullName = serie.fullName;

            this.ShortName = serie.shortName;
        }
 
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(" ");
            sb.Append(this.Fonte);
            sb.Append(" | ");
            sb.Append(this.NomeCompleto);
            sb.Append(" | ");
            sb.Append(this.NomeAbreviado);
            sb.Append(" | ");
            sb.Append(this.GestorProprietario);
            sb.Append(" | ");
            sb.Append(this.FullName);
            sb.Append(" | ");
            sb.Append(this.ShortName);
            sb.Append(" ");
            return sb.ToString();
        }

     
    }
}
