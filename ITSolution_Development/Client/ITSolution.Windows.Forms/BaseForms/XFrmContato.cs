using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Forms
{
    public partial class XFrmContato : DevExpress.XtraEditors.XtraForm
    {
        public Contato Contato { get; private set; }

        public XFrmContato()
        {
            InitializeComponent();
            this.ActiveControl = this.txtNome;
            FormsUtil.AddShortcutEscapeOnDispose(this);
            this.txtTelefone.Enter += new System.EventHandler(this.txt_Enter);
            this.txtTelFixo.Enter += new System.EventHandler(this.txt_Enter);
            this.txtCelular.Enter += new System.EventHandler(this.txt_Enter);

            this.txtNome.Focus();

        }

        public XFrmContato(Contato contato) : this()
        {
            this.Contato = indexarContato(contato);
        }

        public bool IsUpdate { get; private set; }

        private Contato indexarContato()
        {
            Contato novo = new Contato();

            var nomeContato = txtNome.Text;
            var sobreNome = txtSobreNome.Text;
            var nomeMeio = txtSegundoNome.Text;

            var telefone = txtTelefone.Text;
            var celular = txtCelular.Text;
            var telComercial = txtTelFixo.Text;
            var email = txtEmail.Text;

            var endereco = txtEndereco.Text;
            var numEnd = txtNumero.Text;
            var bairro = txtBairro.Text;
            var complemento = txtComplemento.Text;
            var uf = txtUf.Text;
            var cidade = txtCidade.Text;
            var cep = cepControl1.TextCep.Text;


            novo.NomeContato = nomeContato;
            novo.SegundoNomeContato = nomeMeio;
            novo.SobreNomeContato = sobreNome;
            novo.Email = email;

            novo.Telefone = telefone;
            novo.Celular = celular;
            novo.TelefoneFixo = telComercial;

            var e = novo.Endereco;

            e.NomeEndereco = endereco;
            e.NumeroEndereco = numEnd;
            e.Bairro = bairro;
            e.Complemento = complemento;
            e.Cep = cep;
            e.Uf = uf;
            e.Cidade = cidade;

            if (Contato != null)
            {
                novo.IdContato = Contato.IdContato;
            }

            return novo;

        }

        private Contato indexarContato(Contato c)
        {
            if (c != null)
            {

                this.txtNome.Text = c.NomeContato;
                this.txtSobreNome.Text = c.SobreNomeContato;
                this.txtSegundoNome.Text = c.SegundoNomeContato;

                this.txtTelefone.Text = c.Telefone;
                this.txtTelFixo.Text = c.TelefoneFixo;
                this.txtCelular.Text = c.Celular;
                this.txtEmail.Text = c.Email;

                // Seta os dados do endereço nos campos
                var e = c.Endereco;

                //cria uma instancia somente para apagar os dados existentes

                txtEndereco.Text = e.NomeEndereco;
                txtNumero.Text = e.NumeroEndereco;
                txtBairro.Text = e.Bairro;
                txtComplemento.Text = e.Complemento;
                cepControl1.TextCep.Text = e.Cep;

                txtCidade.Text = e.Cidade;
                txtUf.Text = e.Uf;
            }
            return c;
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            var contato = indexarContato();

            if (new ContatoDaoManager().SaveUpdate(contato))
            {
                this.IsUpdate = true;

                this.Contato = contato;
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void txt_Enter(object sender, System.EventArgs e)
        {
            TextEdit t = sender as TextEdit;
            t.SelectAll();
        }

        private void XFrmContato_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                btnSalvar_Click(null, null);
        }
    }
}
