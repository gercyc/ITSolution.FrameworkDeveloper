using ITSolution.Framework.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Entities
{
    [Table("SkinDevExpress")]
    public class SkinDevExpress
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdSkin { get; set; }
 
        [StringLength(100, MinimumLength = 0)]
        public string SkinName { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string SkinNamePtBr { get; set; }
       
        [Required]
        public TypeSkinTheme SkinGroup { get; set; }
    }
}
