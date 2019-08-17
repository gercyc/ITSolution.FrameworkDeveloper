using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITSolution.Framework.Web.Bacen
{
    [Table("ITS_INDICADORES_BACEN")]
    public class IndicadoresBacen
    {

        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdMoeda { get; set; }

        //Esse codigo eh a referencia para realizar a consulta no site do bacen
        public long CodigoMoeda { get; set; }

        [Required]
        [Display(Name = "Código da Moeda")]
        [StringLength(500, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string NomeCompletoMoeda { get; set; }


        public IndicadoresBacen()
        {
        }
    }
}
