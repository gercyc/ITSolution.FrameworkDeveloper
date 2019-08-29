using ITSolution.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses.CommonEntities
{
    [Serializable]
    [Table("CliFor")]
    public class Customer : AbstractClient
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdCliFor { get; set; }
    }
}
