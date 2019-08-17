using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Impressora;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Beans.Forms
{
    /// <summary>
    /// Não foi totalmente testado
    /// </summary>
    public partial class XFrmPrinterText : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        //Controlador
        private PrinterTextUtil util;

        public XFrmPrinterText()
        {
            InitializeComponent();
            carregarListaImpressoras();

            this.util = new PrinterTextUtil(TypePrinter.Documento, this.txtImpressao.Text);
            openFileDialog1.Filter = FileManagerIts.DocumentFilter;


        }

        private void carregarListaImpressoras()
        {
            cbImpressoras.Properties.Items.Clear();

            PrinterTextUtil.GetPrinters().ForEach(delegate (String impressora)
            {
                cbImpressoras.Properties.Items.Add(impressora);
            });

        }

        private void barBtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var impressora = cbImpressoras.SelectedItem;

            util.Print(impressora != null ? impressora.ToString() : null );

        }

        private void barBtnSelecionaArquivo_ItemClick(object sender, ItemClickEventArgs e)
        {

            var op = openFileDialog1.ShowDialog();

            if (op == DialogResult.OK)
            {
                this.util.PathFile = this.openFileDialog1.FileName;
                this.util.Texto = null;
                try {
                    var dados = FileManagerIts.GetDataFile(util.PathFile);
                    txtImpressao.Text = "";
                    dados.ForEach(delegate (String line)
                    {
                        txtImpressao.Text = txtImpressao.Text + "\n" + line;
                    });

                }
                catch(IOException ex)
                {
                    string msg = string.Format("Falha ao abrir o arquivo {0}", util.PathFile);

                    XMessageIts.ExceptionMessageDetails(ex,msg);
                }
            }
        }


        private void barBtnVisualizarImpressao_ItemClick(object sender, ItemClickEventArgs e)
        {            
            util.VisualizarImpressao();
        }

        private void barCheckEditarTextArea_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.txtImpressao.ReadOnly = !this.txtImpressao.ReadOnly;

            if (this.txtImpressao.ReadOnly)
            {
                this.util.PathFile = this.openFileDialog1.FileName;
                this.util.Texto = null;
            }
            else
            {
                this.util.Texto = this.txtImpressao.Text;
                this.util.PathFile = null;

            }
        }

        private void txtImpressao_TextChanged(object sender, EventArgs e)
        {
            this.util.Texto = this.txtImpressao.Text;
        }
    }
}