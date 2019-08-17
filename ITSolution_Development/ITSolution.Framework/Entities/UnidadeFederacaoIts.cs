using System.ComponentModel.DataAnnotations;

namespace ITSolution.Framework.Entities
{
    public class UnidadeFederacaoIts
    {
   
        [Required]
        [StringLength(2)]
        public string CodigoUF { get; set; }

        [StringLength(2)]
        public string CodigoIBGE { get; set; }


        public UnidadeFederacaoIts()
        {

        }
        public override string ToString()
        {
            return CodigoUF;
        }
    }
}
