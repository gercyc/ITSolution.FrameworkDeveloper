using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Web.Correios;

namespace ITSolution.Framework.Components
{
    public partial class CepControl : XtraUserControl
    {
        private TextEdit txtBairro;
        private TextEdit txtEndereco;
        private TextEdit txtCidade;
        private TextEdit txtUf;
        private TextEdit txtComplemento;
        private ComboBoxEdit comboCidade;
        private ComboBoxEdit comboUf;

        public TextEdit TextCep { get { return txtCep; } }
        public string Cep { get; private set; }

        public bool ReadyOnly
        {

            get { return txtCep.ReadOnly && chValidacaoOnline.ReadOnly; }
            set
            {
                txtCep.ReadOnly = value;
                chValidacaoOnline.ReadOnly = value;
            }
        }

        public CepControl()
        {
            InitializeComponent();
            this.lblFlagCep.Visible = false;
            this.ActiveControl = this.txtCep;
            this.txtCep.Focus();

            //addController(new TextEdit(), new TextEdit(), new TextEdit(),
            //    new TextEdit(), new TextEdit(), new TextEdit(), new LookUpMunicipio());
        }

        private void addController(TextEdit txtEndereco,  TextEdit txtComplemento,
                           TextEdit txtBairro, TextEdit txtCidade, TextEdit txtUf,
                           ComboBoxEdit cbCidade, ComboBoxEdit cbUf)
        {
            this.txtEndereco = txtEndereco;
            this.txtComplemento = txtComplemento;

            this.txtBairro = txtBairro;
            this.txtCidade = txtCidade;
            this.txtUf = txtUf;
            this.comboCidade = cbCidade;
            this.comboUf = cbUf;

        }
        public void AddController(ComboBoxEdit cbCidade, ComboBoxEdit cbUf)
        {
            addController(new TextEdit(),new TextEdit(), 
                new TextEdit(), new TextEdit(), new TextEdit(), cbCidade, cbUf);

        }
        public void AddController( TextEdit txtCidade, TextEdit txtUf)
        {
            addController(new TextEdit(), new TextEdit(), new TextEdit(), txtCidade,txtUf, new ComboBoxEdit(), new ComboBoxEdit());
        }

        public void AddController(TextEdit txtEndereco,  TextEdit txtBairro,
            TextEdit txtComplemento, ComboBoxEdit cbCidade, ComboBoxEdit cbUf)
        {
            addController(txtEndereco,  txtComplemento, txtBairro,
                new TextEdit(), new TextEdit(), cbCidade, cbUf);

        }

        public void AddController(TextEdit txtEndereco, TextEdit txtBairro,
            TextEdit txtComplemento, TextEdit txtCidade, TextEdit txtUf)
        {

            addController(txtEndereco,  txtComplemento, txtBairro,
                txtCidade, txtUf, new ComboBoxEdit(), new ComboBoxEdit());

        }

        private async void validaCep()
        {
            if (chValidacaoOnline.Checked)
            {
                XFrmWait.ShowSplashScreen("Validando CEP...");

                //SplashScreenManager.ShowForm(typeof(XFrmWait));

                FindCepIts find = new FindCepIts();

                var result = await find.FindAdress(txtCep.Text);

                this.lblFlagCep.Visible = true;

                if (result)
                {

                    //atualiza o cep
                    this.txtCep.Text = find.Cep;

                    this.Cep = txtCep.Text;

               
                    if (!string.IsNullOrEmpty(find.Bairro))
                        this.txtBairro.Text = find.Bairro;

                    if (!string.IsNullOrEmpty(find.Endereco))
                        this.txtEndereco.Text = find.Endereco;

                    if (!string.IsNullOrEmpty(find.Complemento))
                        this.txtComplemento.Text = find.Complemento;

                    if (!string.IsNullOrEmpty(find.Cidade))
                        this.txtCidade.Text = find.Cidade;

                    if (!string.IsNullOrEmpty(find.UF))
                        this.txtUf.Text = find.UF;


                    if (!string.IsNullOrEmpty(find.Cidade))
                    {
                        this.comboCidade.Properties.Items.Clear();
                        this.comboCidade.Properties.Items.Add(find.Cidade);
                        this.comboCidade.SelectedIndex = 0;
                    }

                    if (!string.IsNullOrEmpty(find.UF))
                    {
                        this.comboUf.Properties.Items.Clear();
                        this.comboUf.Properties.Items.Add(find.UF);
                        this.comboUf.SelectedIndex = 0;
                    }

                    //Flag ok
                    this.lblFlagCep.Appearance.Image = Properties.Resources.apply_16x16;

                }
                else
                {
                    //Flag nao encontrado
                    this.lblFlagCep.Appearance.Image = Properties.Resources.cancel_16x16;


                }

                XFrmWait.CloseSplashScreen();
                //SplashScreenManager.CloseForm();

            }

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
            {
                validaCep();
            }
        }

        private void txtCep_Enter(object sender, System.EventArgs e)
        {
            this.Focus();
            this.txtCep.SelectAll();
        }

        private void txtCep_EditValueChanged(object sender, System.EventArgs e)
        {
            this.Cep = txtCep.Text;
        }
    }
}
