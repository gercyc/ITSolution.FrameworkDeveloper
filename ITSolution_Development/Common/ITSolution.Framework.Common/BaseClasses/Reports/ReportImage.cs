using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    /// <summary>
    /// Objeto com dados do relatório, aqui e armazenado os bytes para gravação no banco
    /// </summary>
    [Serializable]
    [Table("ITS_REPORT_IMAGE")]
    [DataContract]
    public class ReportImage : AbstractReportImage
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID do relatório")]
        [DataMember]
        public int IdReport { get; set; }

        [DataMember]
        public ICollection<ReportDataSource> Datasources { get; set; }


        public ReportImage()
        {
            this.Datasources = new HashSet<ReportDataSource>();
        }
        public ReportImage(string descricaoReport, int grupo)
        {
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo;
        }
        public ReportImage( string descricaoReport, ReportGroup grupo)
        {
            this.Datasources = new HashSet<ReportDataSource>();
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo != null ? grupo.IdGrpReport : 0;
        }

        public ReportImage(string reportName, string descricaoReport, int grupo)
        {
            this.ReportName = reportName;
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo;
        }


        public override string ToString()
        {
            return this.ReportName;
        }
    }
}
