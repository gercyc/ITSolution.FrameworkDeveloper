using System;
using System.Windows.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using System.Threading.Tasks;
using ITSolution.Framework.Web.Correios;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmFindCep : DevExpress.XtraEditors.XtraForm
    {
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string TipoLogradouro { get; set; }

        public XFrmFindCep()
        {
            InitializeComponent();
        }

        private void XFrmFindCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            int lenght = txtCep.Text.Length;

            if (lenght == 5 && e.KeyCode != Keys.Back)
            {
                txtCep.Text = txtCep.Text + "-";
                txtCep.SelectionStart = lenght + 1;
            }
            if (e.KeyCode == Keys.Enter && lenght >= 8)
                btnConsultarCep_Click(null, null);
        }

        private void btnConsultarCep_Click(object sender, EventArgs e)
        {
            XFrmWait.StartTask(findCep(), "Procurando CEP");
        }

        private async Task findCep()
        {
            string cep = txtCep.Text;
            if (!String.IsNullOrWhiteSpace(cep))
            {
                FindCepIts find = new FindCepIts();

                try
                {
                    bool result = await find.FindAdress(cep);

                    this.CEP = find.Cep;
                    this.Cidade = find.Cidade;
                    this.UF = find.UF;
                    this.Bairro = find.Bairro;
                    this.Endereco = find.Endereco;

                    this.txtCep.Text = CEP;
                    this.txtCidade.Text = Cidade;
                    this.txtUF.Text = UF;
                    this.txtBairro.Text = Bairro;
                    this.txtLogradouro.Text = Endereco;

                    if (result)
                        this.lblFlagCep.Visible = true;
                    else
                        this.lblFlagCep.Visible = false;
                }
                catch (Exception ex) { LoggerUtilIts.GenerateLogs(ex); }
            }
        }

        /// <summary>
        /// Dispara a Thread
        /// </summary>
        public void Run()
        {
            this.ShowDialog();
        }

    }
}