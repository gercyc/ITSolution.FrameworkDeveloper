using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Entities
{
    [Table("TipoLogradouro")]
    public class TipoLogradouro
    {
        [Key]
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdTipoLogradouro { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Abreviatura { get; set; }

        public TipoLogradouro()
        {

        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
