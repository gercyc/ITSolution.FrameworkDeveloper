using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmPdfConvertToText : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XFrmPdfConvertToText()
        {
            InitializeComponent();
        }



        private void btnOpenPdf_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = false;
            this.ofd1.Title = "Selecionar PDF";
            if (!ofd1.RestoreDirectory)
                ofd1.InitialDirectory = FileManagerIts.DeskTopPath;
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Files All files (*.*)|*.*|" + " (*.PDF) | *.PDF";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = false;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtPDFfile.Text = ofd1.FileName;

                if (File.Exists(txtPDFfile.Text))
                    barBtnConvertePDF_ItemClick(null, null);
            }
        }

        private async void barBtnConvertePDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await Task.Run(() => converter());
        }

        private void converter()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                String texto = PDFConverter.PrintPDFToText(txtPDFfile.Text);

                this.Invoke(new MethodInvoker(delegate ()
                {
                    richEditControl1.Document.Text = texto;
                }));


                this.barStaticItemPaginas.Caption = "" + PDFConverter.GetNumberPagesOfPDF(txtPDFfile.Text);

            }
            catch (Exception ex)
            {
                var type = ex.GetType();
                if (ex.Message.Contains("not found as file or resource"))
                    XMessageIts.Advertencia("O arquivo PDF a ser convertido não foi informado ",
                            "Atenção");
                else
                    XMessageIts.Advertencia("Arquivo PDF informado é inválido");
            }

        }

        private void txtPDFfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (File.Exists(txtPDFfile.Text))
                    barBtnConvertePDF_ItemClick(null, null);
                else
                    btnOpenPdf_Click(null, null);
        }

        private void barBtnSalvarDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            richEditControl1.SaveDocumentAs();
        }
    }
}
