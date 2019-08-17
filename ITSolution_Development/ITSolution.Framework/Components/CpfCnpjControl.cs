using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Util;
using ITSolution.Framework.Web.JSON;

namespace ITSolution.Framework.Components
{
    public partial class CpfCnpjControl : XtraUserControl
    {

        /// <summary>
        /// Os dados da empresa atualizados pela receita federal
        /// </summary>
        public LayoutReceitaWS ResultValidation { get; private set; }

        public Endereco Endereco { get; private set; }

        public MaskedTextBox MaskedTxtCpfCnpj { get { return this.maskedTxtCpfCnpj; } }

        public bool IsMaskCNPJ { get; set; }

        public TextEdit TextEditRazaoSocial { get; private set; }

        public TextEdit TextEditNomeFantasia { get; private set; }

        public TextEdit TextEditDataSituacao { get; private set; }

        public TextEdit TextEditTelefone { get; private set; }

        public TextEdit TextEditSituacao { get; private set; }

        public DateEdit DateTimePickerAbertura { get; private set; }

        public TextEdit TextEditNaturezaJuridica { get; private set; }

        public DateEdit DateTimePickerUltimaAtualizacao { get; private set; }

        public TextEdit TextEditStatus { get; private set; }

        public TextEdit TextEditTipo { get; private set; }

        public TextEdit TextEditEmail { get; private set; }

        public TextEdit TextEditEFR { get; private set; }

        public TextEdit TextEditMotivoSituacao { get; private set; }

        public TextEdit TextEditSituacaoEspecial { get; private set; }

        public TextEdit TextEditDataSituacaoEspecial { get; private set; }

        public TextEdit TextEditCapitalSocial { get; private set; }

        public TextEdit TextEditTelComercial { get; private set; }
        public Delegate DelegateValidation { get; set; }

        public void AddController(TextEdit txtRazaoSocial,
            TextEdit txtNaturezaJuridica,
            TextEdit txtNomeFantasia,
            DateEdit dtPickerAbertura,
            TextEdit txtSituacao,
            TextEdit txtDataSituacao,
            TextEdit txtSituacaoEspecial,
            TextEdit txtDataSituacaoEspecial,
            TextEdit txtMotivoSituacaoEspecial,
            DateEdit dtPickerAtualizacao,
            TextEdit txtStatus,
            TextEdit txtEFR,
            TextEdit txtEmail,
            TextEdit txtTelefone,
            TextEdit txtTelComercial,
            TextEdit txtTipo,
            TextEdit txtCapitalSocial)
        {
            this.TextEditRazaoSocial = txtRazaoSocial;
            this.TextEditNaturezaJuridica = txtNaturezaJuridica;
            this.TextEditNomeFantasia = txtNomeFantasia;
            this.TextEditSituacao = txtSituacao;


            this.DateTimePickerAbertura = dtPickerAbertura;

            this.TextEditDataSituacao = txtDataSituacao;

            this.TextEditDataSituacaoEspecial = txtDataSituacaoEspecial;

            this.TextEditSituacaoEspecial = txtSituacaoEspecial;
            this.TextEditMotivoSituacao = txtMotivoSituacaoEspecial;

            this.TextEditSituacaoEspecial = txtDataSituacaoEspecial;
            this.DateTimePickerUltimaAtualizacao = dtPickerAtualizacao;

            this.TextEditStatus = txtStatus;
            this.TextEditEFR = txtEFR;

            this.TextEditEmail = txtEmail;

            this.TextEditTelefone = txtTelefone;
            this.TextEditTelComercial = txtTelComercial;

            this.TextEditTipo = txtTipo;

            this.TextEditCapitalSocial = txtCapitalSocial;
        }

        public void AddController(TextEdit txtRazaoSocial)
        {
            this.TextEditRazaoSocial = txtRazaoSocial;
            this.TextEditNaturezaJuridica = new TextEdit();
            this.TextEditNomeFantasia = new TextEdit();
            this.TextEditSituacao = new TextEdit();

            this.DateTimePickerAbertura = new DateEdit();

            this.TextEditDataSituacao = new TextEdit();

            this.TextEditDataSituacaoEspecial = new TextEdit();

            this.TextEditSituacaoEspecial = new TextEdit();
            this.TextEditMotivoSituacao = new TextEdit();

            this.TextEditSituacaoEspecial = new TextEdit();
            this.DateTimePickerUltimaAtualizacao = new DateEdit();

            this.TextEditStatus = new TextEdit();
            this.TextEditEFR = new TextEdit();

            this.TextEditEmail = new TextEdit();

            this.TextEditTelefone = new TextEdit();
            this.TextEditTelComercial = new TextEdit();

            this.TextEditTipo = new TextEdit();

            this.TextEditCapitalSocial = new TextEdit();
        }


        public void AddController(TextEdit txtRazaoSocial, TextEdit txtEmail, TextEdit txtTelefone,
            TextEdit txtTelComercial)
        {
            this.TextEditRazaoSocial = txtRazaoSocial;

            this.TextEditEmail = txtEmail;

            this.TextEditTelefone = txtTelefone;
            this.TextEditTelComercial = txtTelComercial;

            this.TextEditNaturezaJuridica = new TextEdit();
            this.TextEditNomeFantasia = new TextEdit();
            this.TextEditSituacao = new TextEdit();

            this.DateTimePickerAbertura = new DateEdit();

            this.TextEditDataSituacao = new TextEdit();

            this.TextEditDataSituacaoEspecial = new TextEdit();

            this.TextEditSituacaoEspecial = new TextEdit();
            this.TextEditMotivoSituacao = new TextEdit();

            this.TextEditSituacaoEspecial = new TextEdit();
            this.DateTimePickerUltimaAtualizacao = new DateEdit();

            this.TextEditStatus = new TextEdit();
            this.TextEditEFR = new TextEdit();


            this.TextEditTipo = new TextEdit();

            this.TextEditCapitalSocial = new TextEdit();

        }
        public CpfCnpjControl()
        {
            InitializeComponent();
            this.IsMaskCNPJ = true;
        }
        private void showFlagCNPJ(string cnpj)
        {
            this.lblFlagValidando.Visible = false;
            this.lblFlagCnpj.Visible = true;


            if (StringUtilIts.IsCnpj(cnpj) && this.ResultValidation != null)
            {
                this.lblFlagCnpj.Appearance.Image = Properties.Resources.apply_16x16;
                this.maskedTxtCpfCnpj.Enabled = false;
                this.lblFlagCnpj.ToolTip = "CNPJ válido perante a RFB.";
                this.lblValidacaoRFB.Visible = true;

            }
            else if (StringUtilIts.IsCnpj(cnpj))
            {
                this.lblFlagCnpj.Appearance.Image = Properties.Resources.apply_16x16;
                this.maskedTxtCpfCnpj.Enabled = false;
                this.lblValidacaoRFB.Visible = false;
                this.lblFlagValidando.ToolTip = "CNPJ pode não estar regular";

            }
            else
            {
                this.lblFlagCnpj.Appearance.Image = Properties.Resources.cancel_16x16;
                this.lblFlagCnpj.ToolTip = "CNPJ inválido.";
            }



        }

        private bool requestServer(string cnpj)
        {
            this.ResultValidation = LayoutReceitaWS.GetDataFromCNPJ(cnpj);

            return this.ResultValidation != null;

        }
        private async void validationCNPJ()
        {

            string cnpj = maskedTxtCpfCnpj.Text.Trim();
            this.lblFlagValidando.Visible = true;
            if (chValidacaoOnline.Checked)
            {

                bool result = await Task.Factory.StartNew(() => requestServer(cnpj));

                if (result)
                {

                    this.TextEditRazaoSocial.Text = this.ResultValidation.Nome;
                    this.TextEditNomeFantasia.Text = this.ResultValidation.Fantasia;

                    if (!string.IsNullOrEmpty(this.ResultValidation.Abertura))
                        this.DateTimePickerAbertura.DateTime = DataUtil.ToDate(this.ResultValidation.Abertura);

                    this.TextEditSituacao.Text = this.ResultValidation.Situacao;
                    this.TextEditNaturezaJuridica.Text = this.ResultValidation.NaturezaJuridica;

                    if (this.ResultValidation.UltimaAtualizacao.IsValidDate())
                        this.DateTimePickerUltimaAtualizacao.DateTime = this.ResultValidation.UltimaAtualizacao.Value;

                    this.TextEditStatus.Text = this.ResultValidation.Status;

                    this.TextEditEmail.Text = this.ResultValidation.Email;

                    this.TextEditEFR.Text = this.ResultValidation.Efr;

                    this.TextEditDataSituacao.Text = this.ResultValidation.DataSituacao;
                    this.TextEditMotivoSituacao.Text = this.ResultValidation.MotivoSituacao;
                    this.TextEditDataSituacaoEspecial.Text = this.ResultValidation.DataSituacaoEspecial;
                    this.TextEditTipo.Text = this.ResultValidation.Tipo;

                    this.TextEditStatus.Text = this.ResultValidation.Status;
                    this.TextEditCapitalSocial.Text = ParseUtil.ToDecimal(this.ResultValidation.CapitalSocial).ToString("N2");

                    if (!string.IsNullOrEmpty(this.ResultValidation.Telefone))
                    {
                        var tel = this.ResultValidation.Telefone.Split('/');
                        if (tel.Length > 0)
                        {
                            this.TextEditTelefone.Text = tel[0].Trim();

                            if (tel.Length > 1)
                                this.TextEditTelComercial.Text = tel[1].Trim();

                        }
                    }
                    var r = this.ResultValidation;

                    this.Endereco = new Endereco(r.Logradouro, r.Numero, r.Bairro,
                                                r.Complemento, r.Cep, r.Uf, r.Municipio, "");
                    //ws nao traz o tipo
                    this.Endereco.TipoEndereco = "Correspondência";

                    DelegateValidation.DynamicInvoke();
                }
            }
            showFlagCNPJ(cnpj);


        }

        private void maskedTxtCpfCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                validationCNPJ();
        }

        private void lblValidacaoRFB_Click(object sender, EventArgs e)
        {
            validationCNPJ();
        }

        private void maskedTxtCpfCnpj_MaskChanged(object sender, EventArgs e)
        {
            this.lblFlagCnpj.Visible = false;

            if (this.IsMaskCNPJ)
            {
                this.panelControl1.Visible = true;
                this.IsMaskCNPJ = true;
                this.lblValidacaoRFB.Visible = true;

            }
            else
            {
                this.maskedTxtCpfCnpj.Enabled = true;
                this.panelControl1.Visible = false;
                this.IsMaskCNPJ = false;
                this.lblValidacaoRFB.Visible = false;
            }
        }

        public void SetMaskCNPJ()
        {
            this.IsMaskCNPJ = true;
            this.MaskedTxtCpfCnpj.Mask = "00\\.000\\.000\\/0000\\-00";

        }

        public void SetMaskCPF()
        {
            this.IsMaskCNPJ = false;
            this.MaskedTxtCpfCnpj.Mask = "000\\.000\\.000\\-00";
        }

        private void CNPJControl_Load(object sender, EventArgs e)
        {
        }

        private void chValidacaoOnline_CheckedChanged(object sender, EventArgs e)
        {
            this.lblFlagValidando.Visible = false;


        }
    }
}
