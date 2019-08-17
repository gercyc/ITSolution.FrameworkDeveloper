using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Web.Bacen
{
    /// <summary>
    /// Lista de todos os códigos que são utilizados no serviço FachadaWSSGS
    /// </summary>
    [Table("ITS_MOEDA")]
    public class Moeda
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        [Display(Name = "ID Moeda")]
        public int IdMoeda { get; set; }

        [Required]
        [Display(Name = "Nome da moeda")]
        [StringLength(50, MinimumLength = 3)]
        [Column(TypeName = "varchar")]
        public string NomeMoeda { get; set; }

        public long CodigoWSCompra { get; set; }

        public long CodigoWSVenda { get; set; }

        public virtual ICollection<CotacaoMonetaria> CotacaoMonetaria { get; set; }


        public Moeda()
        {
            this.CotacaoMonetaria = new HashSet<CotacaoMonetaria>();
        }

        public Moeda(TypeCodigoBacen codCompra, TypeCodigoBacen codVenda)
        {

            this.CodigoWSCompra = (long)codCompra;
            this.CodigoWSVenda = (long)codVenda;
        }

        public override string ToString()
        {
            return this.NomeMoeda;
        }
    }
}
