using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Entities
{
    //Vou usar essa classe para salvar lembrete e exibir no panel do menu princiapl
    //sem abri o panel quando o usuario salvar seus lembretes
    public class Lembrete
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdLembrete { get; set; }

        [StringLength(200)]
        [Display(Name = "Lembrete")]
        public string NomeLembrete { get; set; }

        [Display(Name = "Mensagem:")]
        [Column(TypeName = "Text")]
        public string Texto { get; set; }

        public Lembrete()
        {
        }

        public Lembrete(string nomeLembrete, string texto)
        {
            NomeLembrete = nomeLembrete;
            Texto = texto;
        }

        public void Update(Lembrete l)
        {
            NomeLembrete = l.NomeLembrete;
            Texto = l.Texto;
        }
    }
}
