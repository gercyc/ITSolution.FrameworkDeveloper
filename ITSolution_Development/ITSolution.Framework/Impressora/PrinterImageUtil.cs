using ITSolution.Framework.Impressora;
using ITSolution.Framework.Mensagem;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using ITSolution.Framework.Arquivos;

namespace ITSolution.Framework.Util
{
    public class PrinterImageUtil : PrinterUtilIts
    {
        public List<Image> Images { get; private set; }

        public PrinterImageUtil()
        {
            this.Images = new List<Image>();
            this.PrintDocument.PrintPage += PrintDocument_PrintImage;
        }

        /// <summary>
        /// Guarda a imagem
        /// </summary>
        /// <param name="file"></param>Arquivo de imagem
        public void AddImage(string file)
        {

            try
            {
                var img = ImageUtilIts.GetImageFromFile(file);
                //add a imagem
                this.Images.Add(img);
                //add o caminho da imagem
                this.ImagesPath.Add(file);

                //copie o arquivo pro temporario
                //FileManagerIts.CopyFile(Path.GetTempPath(), getPathTemp(file));

            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha ao obter imagem");
            }
        }

        /// <summary>
        /// Visualizar a ultima imagem usando o visualizador de imagem do windows
        /// Visualizao último arquivo adicionado
        /// </summary>
        public void View()
        {
            if (ImagesPath.Count == 0)
                XMessageIts.Mensagem("Nada a ser visualizado !");
            else
                this.View(this.ImagesPath.Last());
        }

        /// <summary>
        /// Visualizar imagem usando o visualizador de imagem do windows
        /// </summary>
        public void View(string imagePath)
        {
            try
            {
                Process.Start(imagePath);
            }
            catch (Exception ex)
            {
                if (imagePath == null)
                {
                    XMessageIts.Mensagem("Imagem não foi informada para visualização");
                }
                else
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Falha ao abrir imagem");
                }
            }
        }

        /// <summary>
        /// Visualiza o ultimo arquivo informado
        /// </summary>
        /// <returns></returns>
        public bool PrintView()
        {
            var pathFile = this.ImagesPath.Last();
            if (string.IsNullOrWhiteSpace(pathFile))
            {
                XMessageIts.Mensagem("Nada a ser visualizado");
            }
            else if (!File.Exists(pathFile))
            {

                XMessageIts.Advertencia(pathFile + " não existe", "Arquivo não encontrado");
            }
            else
            {

                try
                {
                    if (String.IsNullOrWhiteSpace(pathFile))
                    {
                        string docName = Path.GetFileName(pathFile);
                        this.PrintDocument.DocumentName = docName;
                    }
                    this.PrintDocument.PrintPage += this.PrintDocument_PrintImage;
                    this.PrintPreviewDialog.Document = PrintDocument;
                    this.PrintPreviewDialog.ShowDialog();
                    this.PrintDocument.PrintPage += null;
                    return true;
                }
                catch (Exception ex)
                {

                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            return false;

        }

        public void PrintDocument_PrintImage(object sender, PrintPageEventArgs e)
        {
            var printDocument = sender as System.Drawing.Printing.PrintDocument;

            if (printDocument != null)
            {
                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                var pathFile = this.ImagesPath.Last();
                if (!String.IsNullOrWhiteSpace(pathFile) && File.Exists(pathFile))
                {
                    var image = System.Drawing.Image.FromFile(pathFile);

                    if (image.Width > 1000)
                    {
                        var bitmap = new Bitmap(image, new Size(955, 768));
                        e.Graphics.DrawImage(bitmap, new Point(50, 50));
                    }
                    else
                        e.Graphics.DrawImage(image, new Point(100, 100));

                }

                /*
                // The following demonstrates the anonymous method feature of C#
                this.ImageBytes.ForEach(delegate (byte[] bytes)
                {
                    e.Graphics.DrawImage(ImageUtilIts.GetImageFromBytes(bytes), 0, 0);
                });*/

                // Check to see if more pages are to be printed.
                //e.HasMorePages = (this.ImageBytes.Count > 0);


            }
            else
            {
                XMessageIts.Advertencia("Nenhum arquivo a ser impresso não existe");
            }

        }

    }
}
