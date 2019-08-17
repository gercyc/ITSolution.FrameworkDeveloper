using ITSolution.Framework.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Admin.Entidades.EntidadesBd
{
    [Table("ITS_PACKAGE_ANEXO")]
    [Serializable]
    public class AnexoPackage : AbstractAttach
    {
        [Key]//pk
        [Column]
        public int IdAnexo { get; set; }

        public int IdPacote { get; set; }

        [ForeignKey("IdPacote ")]
        public Package Pacote { get; set; }//virtual desabilitado para nao gerar sobrecarga


        public AnexoPackage()
        {

        }
        public AnexoPackage(byte[] dataFile, string fileName, string path)
            : base(dataFile, fileName, path)
        {
        }
        public AnexoPackage(string path)
            : base(path)
        {
        }
        public override string ToString()
        {
            return "Pacote_" + this.IdPacote + "_Anexo_" + this.FileName;
        }
    }
}
