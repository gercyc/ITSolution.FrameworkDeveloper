using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ITSolution.Framework.Common.BaseClasses.Reports
{
    /// <summary>
    /// Grupo de relatórios
    /// </summary>
    [Table("ITS_REPORT_GROUP")]
    [Serializable]
    [DataContract]
    public class ReportGroup
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Grupo")]
        [DataMember]
        public int IdGrpReport { get; set; }

        [Display(Name = "Descrição Grupo")]
        [StringLength(200, MinimumLength = 5)]
        [DataMember]
        public string GroupDescription { get; set; }

        [Display(Name = "Data Criação Grupo")]
        public DateTime CreationTime { get; set; }

        //virtual removido => Lazy.Loading desativado 
        public ICollection<DashboardImage> Dashboards{ get; set; }

        public virtual ICollection<ReportImage> Relatorios {get;set;}

        public ReportGroup()
        {
            this.Relatorios = new HashSet<ReportImage>();
        }

        public override string ToString()
        {
            return this.GroupDescription;
        }
    }
}
