using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    /// <summary>
    /// Objeto do spool de relatórios
    /// </summary>
    [Table("ITS_SPOOL_REL")]
    public class ReportSpool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Spool")]
        public int IdSpool {get;set;}

        [Display(Name = "Data Geração")]
        public DateTime GenerateTime { get; set; }

        [Display(Name = "Nome Relatório")]
        [StringLength(200, MinimumLength = 5)]
        public string ReportName { get; set; }

        [Display(Name = "Imagem Relatório")]
        public byte[] ReportSpoolImage { get; set; }

        public ReportSpool(DateTime dtGeracao, String nomeRelatorio, byte[] bytesRelatorio)
        {
            this.GenerateTime = dtGeracao;
            this.ReportName = nomeRelatorio;
            this.ReportSpoolImage = bytesRelatorio;
        }
        public ReportSpool()
        {

        }
    }
}
