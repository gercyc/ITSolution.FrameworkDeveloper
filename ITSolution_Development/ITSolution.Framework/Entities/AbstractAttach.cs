using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ITSolution.Framework.Entities
{
    [Serializable]
    public abstract class AbstractAttach
    {

        public DateTime DataAnexo { get; set; }

        [StringLength(150)]
        public string IdentificacaoAnexo { get; set; }

        [Display(Name = "Path do Anexo")]
        [StringLength(1000)]
        public string PathFile { get; set; }

        [Display(Name = "Nome do Anexo")]
        [StringLength(200)]
        public string FileName { get; set; }

        [Display(Name = "Dados do Anexo")]
        public byte[] DataFile { get; set; }


        [NotMapped]
        public string Extensao
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(PathFile))
                        return Path.GetExtension(PathFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha ao obter extensao do anexo" + ex.Message);
                }
                return "";
            }
        }
        public AbstractAttach()
        {

        }
        public AbstractAttach(string path)
        {
            try
            {
                this.DataAnexo = DateTime.Now;
                this.PathFile = path;

                //a extensao eh obtida a partir do PathFile
                this.FileName = Path.GetFileName(path);

                if (File.Exists(PathFile))
                {
                    this.DataFile = FileManagerIts.GetBytesFromFile(path);

                    //por padrao eh o nome do arquivo sem a extensao 
                    //a extensao eh obtida a partir do PathFile
                    this.IdentificacaoAnexo = Path.GetFileNameWithoutExtension(path);
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionJustMessage(ex, "Falha na criação do anexo");
            }

        }
        public AbstractAttach(byte[] dataFile, string fileName, string path):this(path)
        {
            this.FileName = fileName;
            this.DataFile = dataFile;
        }

        public AbstractAttach(string path, byte[] data)
        {
            try
            {
                this.PathFile = path;
                this.FileName = Path.GetFileName(path);
                this.DataFile = data;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
        }


        public virtual void Update(AbstractAttach anexo)
        {
            this.IdentificacaoAnexo = anexo.IdentificacaoAnexo;
            this.DataAnexo = anexo.DataAnexo;
            this.DataFile = anexo.DataFile;
            this.FileName = anexo.FileName;
        }

    }
}
