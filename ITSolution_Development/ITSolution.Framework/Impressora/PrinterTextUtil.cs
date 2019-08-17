using ITSolution.Framework.Enumeradores;
using ITSolution.Framework.Mensagem;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace ITSolution.Framework.Impressora
{
    public class PrinterTextUtil : PrinterUtilIts
    {


        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;

        //Texto a ser impresso  
        public String Texto { get; set; }

        /// <summary>
        /// Path do arquivo a ser impresso pelo PrintDocument
        /// </summary>
        public string PathFile { get; set; }

        public PrinterTextUtil(TypePrinter typePrinter, string pathFileOrText) : base()
        {
            if (typePrinter == TypePrinter.Documento)
            {
                this.PathFile = pathFileOrText;
                this.Texto = null;
            }
            else
            {
                this.Texto = pathFileOrText;
                this.PathFile = null;
            }

        }

        public override void Print(string impressora)
        {
            this.PrintDocument.PrintPage += PrintDocument_PrintText;
            this.PrintDocument.Print();
            this.PrintDocument = null;
        }

        public bool VisualizarImpressao()
        {
            if (readDocument())
            {
                this.PrintDocument.PrintPage += this.PrintDocument_PrintText;
                this.PrintPreviewDialog.Document = this.PrintDocument;
                this.PrintPreviewDialog.ShowDialog();
                return true;
            }
            return false;

        }


        /// <summary>
        /// Evento para configurar o PrintDocument para imprimir o texto informado no construtor
        /// Use  this.printDocument1.PrintPage += objeto.PrintDocument_PrintText;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintText(object sender, PrintPageEventArgs e)
        {

            //https://msdn.microsoft.com/pt-br/library/ms404294%28v=vs.110%29.aspx

            if (!String.IsNullOrWhiteSpace(this.PathFile) && !String.IsNullOrWhiteSpace(this.Texto))
            {
                int charactersOnPage = 0;
                int linesPerPage = 0;

                var font = new Font("Times New Roman", 14);
                // Sets the value of charactersOnPage to the number of characters 
                // of stringToPrint that will fit within the bounds of the page.
                e.Graphics.MeasureString(stringToPrint, font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page.
                e.Graphics.DrawString(stringToPrint, font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

                // Remove the portion of the string that has been printed.
                stringToPrint = stringToPrint.Substring(charactersOnPage);

                // Check to see if more pages are to be printed.
                e.HasMorePages = (stringToPrint.Length > 0);

                // If there are no more pages, reset the string to be printed.
                if (!e.HasMorePages)
                    stringToPrint = documentContents;

            }
            else
            {

                if (this.Texto != null)
                {
                    //http://www.andrealveslima.com.br/blog/index.php/2015/09/30/impressao-direto-na-impressora-com-c/
                    using (var fonte = new Font("Times New Roman", 14))
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        int caracteresNaPagina = 0;
                        int linhasPorPagina = 0;

                        e.Graphics.MeasureString(
                            Texto, fonte, e.MarginBounds.Size, StringFormat.GenericTypographic,
                            out caracteresNaPagina, out linhasPorPagina);

                        e.Graphics.DrawString(
                            Texto.Substring(0, caracteresNaPagina),
                            fonte,
                            brush,
                            e.MarginBounds);

                        Texto = Texto.Substring(caracteresNaPagina);

                        e.HasMorePages = Texto.Length > 0;
                    }
                }

            }


        }


        /// <summary>
        /// Chamado internamente
        /// </summary>
        /// <param name="printDocument"></param>
        private bool readDocument()
        {
            if (String.IsNullOrWhiteSpace(this.PathFile) && String.IsNullOrWhiteSpace(Texto))
            {
                //Tbm nao tem texto
                XMessageIts.Mensagem("Nada a ser visualizado");

            }

            else if (!String.IsNullOrWhiteSpace(Texto))
            {
                //use o texto
                this.documentContents = this.Texto;
                this.stringToPrint = this.documentContents;
                return true;
            }
            else if (!File.Exists(this.PathFile))
            {
                MessageBox.Show(PathFile + " não existe", "Arquivo não encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                string docName = Path.GetFileName(this.PathFile);
                //string docPath = Path.GetDirectoryName(this.PathFile);
                PrintDocument.DocumentName = docName;

                using (FileStream stream = new FileStream(this.PathFile, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    this.documentContents = reader.ReadToEnd();
                }
                this.stringToPrint = this.documentContents;
                return true;

            }
            return false;

        }

    }
}
