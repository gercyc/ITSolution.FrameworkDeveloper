using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Entities
{
    [Table("Parametro")]
    public class Parametro
    {
        [Key]
        [StringLength(120, MinimumLength = 0)]
        public string CodigoParametro { get; set; }

        [StringLength(300, MinimumLength = 0)]
        public string ValorParametro { get; set; }

        public bool StatusParametro { get; set; }

        [StringLength(300, MinimumLength = 0)]
        public string DescricaoParametro { get; set; }

        public Parametro()
        {
        }

        public Parametro(string codigo, string valorParam)
        {
            this.CodigoParametro = codigo;
            this.ValorParametro = valorParam;
            this.StatusParametro = true;
        }


        public Parametro(TypeParametro codigo, string valorParam, bool status)
        {
            this.CodigoParametro = codigo.ToString();
            this.ValorParametro = valorParam;
            this.StatusParametro = status;
        }

        public void Update(Parametro novo)
        {
            //codigo eh inalteravel via instrução C#
            this.ValorParametro = novo.ValorParametro;
            this.StatusParametro = novo.StatusParametro;
        }
    }
}
