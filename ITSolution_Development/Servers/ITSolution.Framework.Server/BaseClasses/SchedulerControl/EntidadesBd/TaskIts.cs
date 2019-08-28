using ITSolution.Scheduler.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ITSolution.Scheduler.EntidadesBd
{
    [Serializable]
    [Table("ITS_SCHEDULER_TASK")]
    public class TaskIts
    {

        [Key]
        [StringLength(38)]
        public string IdTask { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime? DtInicio { get; set; }

        public DateTime? DtTermino { get; set; }

        public int Frequencia { get; set; }

        public int Intervalo { get; set; }

        public int IdUsuario { get; set; }

        [StringLength(200)]
        public string Classe { get; set; }

        [StringLength(50)]
        public string Metodo { get; set; }

        [StringLength(1000)]
        public string Parametros { get; set; }

        [StringLength(1000)]
        public string DescricaoTarefa { get; set; }

        public TaskStatusIts StatusTask { get; set; }

        public string IdProcess { get; set; }

        public byte[] Tarefa { get; set; }

        [ForeignKey("IdProcess")]
        public virtual ProcessIts Processo { get; set; }

        public ICollection<LogIts> TaskDetails { get; set; }

        //[NotMapped]

        public TaskIts()
        {
            TaskDetails = new HashSet<LogIts>();
        }
        

        public TaskIts(string classe, string metodo, string parameters)
        {
            this.Classe = classe;
            this.Metodo = metodo;
            this.Parametros = parameters;
        }

        public TaskIts(string idTask, int frequencia, int intervalo,
            int IdUsuario, string classe, string metodo,
            string descricaoTarefa, string idProcess, byte[] task)
        {
            this.IdTask = idTask;
            this.DtCriacao = DateTime.Now;
            this.StatusTask = TaskStatusIts.Agendada;
            this.Frequencia = frequencia;
            this.Intervalo = intervalo;
            this.IdUsuario = IdUsuario;
            this.Classe = classe;
            this.Metodo = metodo;
            this.Parametros = String.Empty;
            this.DescricaoTarefa = descricaoTarefa;
            this.IdProcess = idProcess;
            this.Tarefa = task;
        }

    }
}
