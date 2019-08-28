using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Scheduler.EntidadesBd
{
    [Table("ITS_PROCESS")]
    public class ProcessIts
    {
        [Key]
        public string IdProcess { get; set; }

        [StringLength(50)]
        public string NomeProcesso { get; set; }

        [StringLength(200)]
        public string DescricaoProcesso { get; set; }
                
        public int TipoProcesso { get; set; }

        [StringLength(200)]
        public string ClassName { get; set; }

        [StringLength(50)]
        public string Metodo { get; set; }

        public byte[] Parametros { get; set; }

        [StringLength(50)]
        public string CodigoProcesso { get; set; }

        public ProcessIts()
        {

        }
        public override string ToString()
        {
            return this.NomeProcesso;
        }

    }
}
