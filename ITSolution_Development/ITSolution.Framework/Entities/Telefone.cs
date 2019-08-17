using System.ComponentModel.DataAnnotations;

namespace ITSolution.Framework.Entities
{
    public class Telefone
    {        
        public string CodigoPais{ get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string DDD { get; set; }

        [StringLength(20, MinimumLength = 8)]
        public string NumeroTelefone { get; set; }

        public Telefone()
        {

        }

        public override string ToString()
        {
            return "+" + CodigoPais + " (" + DDD + ") " + NumeroTelefone;
        }
    }
}
