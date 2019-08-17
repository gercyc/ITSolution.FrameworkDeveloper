using System;
using System.ComponentModel.DataAnnotations;

namespace ITSolution.Framework.Entities
{
    public class Mensagem
    {
        public DateTime Data { get; set; }

        [Display(Name ="Mensagem")]
        public string MensagemInfo { get; set; }

        public Mensagem(string msgInfo)
        {
            this.Data = DateTime.Now;
            this.MensagemInfo = msgInfo;
        }
        public Mensagem()
        {

        }
    }
}
