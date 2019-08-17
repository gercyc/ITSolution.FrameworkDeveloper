using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses
{
    [Table("ITS_TRANSACTION")]
    public class TransactionInfo
    {
        [Key]
        public string IdTransaction { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionShortcut { get; set; }
        public string TransactionType { get; set; }

        public TransactionInfo()
        {

        }
    }
}
