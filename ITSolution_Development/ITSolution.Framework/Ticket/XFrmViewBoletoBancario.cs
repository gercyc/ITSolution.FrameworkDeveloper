using System.Windows.Forms;

namespace ITSolution.Framework.Ticket
{
    public partial class XFrmViewBoletoBancario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Nao vou implementar isso agora 
        //Que trabalheira q deu fazer o boleto
        public XFrmViewBoletoBancario()
        {
            InitializeComponent();
        }

        public void ShowBoleto(string pathLayout)
        {
            webBrowser.Navigate(pathLayout);
        }
        private void backstageTabSave_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            var op = saveFileDialog.ShowDialog();
            if (op == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                var bmp = BoletoUtil.CreateImage(webBrowser.Url.ToString());
                bmp.Save(path);
            }
        }

        private void backstageTabConfigPag_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            PageSetupDialog Janela = new PageSetupDialog();
            webBrowser.ShowPrintPreviewDialog();
        }

        private void backstageTabPrintView_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            webBrowser.ShowPrintPreviewDialog();
        }

        private void backstageTabPrint_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            webBrowser.ShowPrintDialog();
        }

        private void backstageTabExit_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            this.Dispose();
        }
        //cada back stage tem o seu controle
    }
}