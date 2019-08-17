using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITE.Entidades.POCO.TI
{
    [Serializable]
    public class Computer
    {

        [Required]
        //[Column("nomePlacaMae")]
        [Display(Name = "Placa mãe")]
        [StringLength(100, MinimumLength = 5)]
        public string NomePlacaMae { get; set; }

        [Required]
        //[Column("processador")]
        [Display(Name = "Processador")]
        [StringLength(100, MinimumLength = 5)]
        public string Processador { get; set; }

        [Required]
        //[Column("memoriaRam")]
        [Display(Name = "Memória RAM")]
        [StringLength(100, MinimumLength = 3)]
        public string MemoriaRam { get; set; }

        [Required]
        //[Column("hd")]
        [Display(Name = "Disco rígido")]
        [StringLength(100, MinimumLength = 2)]
        public string Hd { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string NomeComputador { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string GrupoTrabalho { get; set; }

        public Computer()
        {
        }

        public Computer(string placaMae, string proc, string hd, string ram, string nomePC,
                string grupoTrabalho)
        {

            this.NomePlacaMae = placaMae;
            this.Processador = proc;
            this.Hd = hd;
            this.MemoriaRam = ram;
            this.NomeComputador = nomePC;
            this.GrupoTrabalho = grupoTrabalho;
        }

        public void Update(Computer novo)
        {
            this.NomePlacaMae = novo.NomePlacaMae;
            this.Processador = novo.Processador;
            this.Hd = novo.Hd;
            this.MemoriaRam = novo.MemoriaRam;
            this.NomeComputador = novo.NomeComputador;
            this.GrupoTrabalho = novo.GrupoTrabalho;
        }

    }
}
