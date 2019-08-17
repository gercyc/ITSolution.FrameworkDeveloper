using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITSolution.Framework.Entities
{
    public class Contato
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdContato { get; set; }

        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Nome")]
        public string NomeContato { get; set; }

        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Segundo Nome")]
        public string SegundoNomeContato { get; set; }

        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Sobre Nome")]
        public string SobreNomeContato { get; set; }

        [StringLength(500)]
        [Display(Name = "Web Site")]
        public string Website { get; set; }

        [StringLength(300, MinimumLength = 0)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string Celular { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string Telefone { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string TelefoneFixo { get; set; }

        public virtual Endereco Endereco { get; set; }

        [NotMapped]
        public string NomeCompleto
        {
            get
            {
                var nome = new StringBuilder(this.NomeContato);

                if (!string.IsNullOrEmpty(SegundoNomeContato))
                {
                    nome.Append(" ");
                    nome.Append(SegundoNomeContato);
                }
                else if (!string.IsNullOrEmpty(SobreNomeContato))
                {
                    nome.Append(" ");
                    nome.Append(SobreNomeContato);
                }

                return nome.ToString();
            }
        }

        public Contato()
        {
            this.Endereco = new Endereco();
        }

        public void Update(Contato novo)
        {
            this.NomeContato = novo.NomeContato;
            this.SegundoNomeContato = novo.SegundoNomeContato;
            this.SobreNomeContato = novo.SobreNomeContato;
            this.Email = novo.Email;

            this.Telefone = novo.Telefone;
            this.Celular = novo.Celular;
            this.TelefoneFixo = novo.TelefoneFixo;

            this.Endereco = novo.Endereco;
   
        }
    }
}
