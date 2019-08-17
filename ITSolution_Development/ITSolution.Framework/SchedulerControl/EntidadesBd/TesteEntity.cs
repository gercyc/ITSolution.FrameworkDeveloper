using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Scheduler.EntidadesBd
{
    [Table("TB_TESTE")]
    public class TesteEntity
    {
        [Key]
        [StringLength(38)]
        public string TesteID { get; set; }

        [StringLength(100)]
        public string Mensagem { get; set; }


        public TesteEntity()
        {

        }
        public TesteEntity(String id, String msg)
        {
            this.TesteID = id;
            this.Mensagem = msg;
        }
    }
}
