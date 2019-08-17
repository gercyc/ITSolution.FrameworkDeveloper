using System;
using System.Windows.Forms;


namespace ITSolution.Framework.Ticket
{
    public partial class XFrmViewBoleto : DevExpress.XtraEditors.XtraForm
    {
        public XFrmViewBoleto()
        {
            InitializeComponent();


        }

        public void ShowBoleto(string pathLayout)
        {
            webBrowser.Navigate(pathLayout);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintPreviewDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var op = saveFileDialog.ShowDialog();
            if (op == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                var bmp = BoletoUtil.CreateImage(webBrowser.Url.ToString());
                bmp.Save(path);
            }
            //retorna o path da imagem
            //BoletoUtil.GenerateImage(webBrowser.Url.ToString());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PageSetupDialog Janela = new PageSetupDialog();
            webBrowser.ShowPrintPreviewDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            webBrowser.ShowSaveAsDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser.Document.Encoding = "ISO-8859-1";
            this.webBrowser.Document.Body.Style = "zoom:200%;";
        }

    }
}
