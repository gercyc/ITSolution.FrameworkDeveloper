using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    /// <summary>
    /// Objeto com dados do relatório, aqui e armazenado os bytes para gravação no banco
    /// </summary>
    [Table("ITS_DASHBOARD_IMAGE")]
    [Serializable]
    public class DashboardImage : AbstractReportImage
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Relatório")]
        public int IdReport { get; set; }

        public DashboardImage()
        {
        }
        public DashboardImage(int idGrupo, string nameDashboard, byte[] bytes)
        {
            this.IdGrpReport = idGrupo;
            this.ReportName = nameDashboard;
            this.ReportImageData = bytes;
        }
        public DashboardImage(string descricaoDashboard, ReportGroup grupo):base(descricaoDashboard, grupo)
        {
        }

        public DashboardImage(string descricaoDashboard, int idGrupoRelatorio):base(descricaoDashboard, idGrupoRelatorio)
        {
        }

        public override string ToString()
        {
            return this.ReportName;
        }
    }
     
}
