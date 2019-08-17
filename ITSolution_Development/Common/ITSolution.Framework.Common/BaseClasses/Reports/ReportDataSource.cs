using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    [Table("ITS_REPORT_DATASOURCE")]
    public class ReportDataSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdDataSource { get; set; }
        public int IdReport { get; set; }
        public string IdQuery { get; set; }

        public bool Datamember { get; set; }
        
        [ForeignKey("IdReport")]
        public virtual ReportImage ReportImage { get; set; }
        [ForeignKey("IdQuery")]
        public virtual SqlQueryIts Consulta { get; set; }
    }
}
