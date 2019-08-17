using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    [Serializable]
    [DataContract]
    public abstract class AbstractReportImage
    {

        [DataMember]
        [Display(Name = "ID Grupo")]
        public int IdGrpReport { get; set; }

        [DataMember]
        [Display(Name = "Nome do Relatório")]
        [StringLength(200, MinimumLength = 5)]
        public string ReportName { get; set; }

        [DataMember]
        [Display(Name = "Descrição do Relatório")]
        [StringLength(200, MinimumLength = 5)]
        public string ReportDescription { get; set; }
        
        [Display(Name = "Estrutura do relatório")]
        public byte[] ReportImageData { get; set; }

        [DataMember]
        [ForeignKey("IdGrpReport")]
        public virtual ReportGroup Grupo { get; set; }

        [NotMapped]
        public string DefaultName { get; set; }

        public AbstractReportImage()
        {
        }
        public AbstractReportImage(string descricaoReport, int grupo)
        {
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo;
        }
        public AbstractReportImage(string descricaoReport, ReportGroup grupo)
        {
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo != null ? grupo.IdGrpReport : 0;
        }

        public AbstractReportImage(string reportName, string descricaoReport, int grupo)
        {
            this.ReportName = reportName;
            this.ReportDescription = descricaoReport;
            this.IdGrpReport = grupo;
        }

        public void Update(AbstractReportImage report)
        {
            this.ReportImageData = report.ReportImageData;
            this.ReportName = report.ReportName;
            this.ReportDescription = report.ReportDescription;
            this.IdGrpReport = report.IdGrpReport;
        }

        public override string ToString()
        {
            return this.ReportName;
        }
    }
}
