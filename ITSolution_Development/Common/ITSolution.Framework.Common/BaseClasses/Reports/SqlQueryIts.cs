using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    [Table("ITS_SQL_QUERIES")]
    public class SqlQueryIts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdQuery { get; set; }

        public string CodigoQuery { get; set; }

        public string NomeQuery { get; set; }

        public string CorpoQuery { get; set; }

        public DateTime DataCriacao { get; set; }

        public Nullable<DateTime> DataAlteracao { get; set; }       

        public void Update(SqlQueryIts novo)
        {
            this.CodigoQuery = novo.CodigoQuery;
            this.NomeQuery = novo.NomeQuery;
            this.CorpoQuery = novo.CorpoQuery;
            this.DataAlteracao = DateTime.Now;
        }

    }
}
