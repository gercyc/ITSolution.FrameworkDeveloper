using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses.CommonEntities
{
    [Table("Usuario")]
    public class ItsUser : AbstractUser
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdUsuario { get; set; }
    }

}
