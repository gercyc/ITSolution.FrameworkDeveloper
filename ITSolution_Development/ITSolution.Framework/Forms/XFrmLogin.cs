using System;
using System.Windows.Forms;
using ITSolution.Framework.Listeners;
using ITSolution.Framework.Validador;
using ITSolution.Framework.Mensagem;
using System.ComponentModel.DataAnnotations;
using ITSolution.Framework.Util;
using System.IO;
using System.Drawing;
using DevExpress.XtraEditors;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Framework.Forms
{

    public partial class XFrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private static string PATH_BACKGROUND = Path.Combine(Application.StartupPath, "background_login");
        /// <summary>
        /// true Login efetuado caso contrário false
        /// </summary>
        public bool IsLogin { set; get; }
        /// <summary>
        /// Ação a ser invocada a após a permissão login
        /// </summary>
        private ActionLogin action;
        /// <summary>
        /// Usuário que está realizando Login
        /// </summary>
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsCancel { get; set; }
        public bool IsLembraMe { get { return this.chLembrarMe.Checked; } }

        /// <summary>
        ///Limpa os campos sempre que o form é exibido
        /// </summary>
        public bool CleanOnStart { get; set; }

        public Delegate ActionBtn { get; set; }

        public SimpleButton BtnAction { get { return btnActionBtn; } }

        /// <summary>
        /// Padrão é true - fecha o form quando realiza o login
        /// </summary>
        public bool IsHideOnLogin { get; set; }


        /// <summary>
        /// O login nao sera fechado ao clica no botao entrar
        /// </summary>
        public bool DisposeOnLogin { get; set; }

        #region Form move control

        private bool mouseMove;
        private int mValX;
        private int mValY;

        #endregion

        #region Construtores
        public XFrmLogin()
        {
            InitializeComponent();
            this.ActiveControl = this.txtNome;
            this.txtNome.Focus();
            this.openFileDialog1.Filter = ImageUtilIts.ImageFilter;
            this.refreshClockDate();
            this.DisposeOnLogin = true;

            if (File.Exists(PATH_BACKGROUND))
                panelControl1.ContentImage = Image.FromFile(PATH_BACKGROUND);

        }

        public XFrmLogin(ActionLogin actionLogin)
            : this()
        {
            this.action = actionLogin;
        }
        #endregion

        #region Metodos 
        private void refreshClockDate()
        {

            //atualiza o label a cada 1 seg
            this.lblHrs.Text = DateTime.Now.ToLongTimeString();
            this.lblData.Text = DateTime.Now.Date.ToLongDateString();
        }
        private Usuario indexarDados()
        {
            string nomeUsuario = txtNome.Text;
            string pw = txtSenha.Text;

            return new Usuario(nomeUsuario, pw);
        }

        public void Run()
        {
            //Show();
            this.ShowDialog();
        }


        public TextEdit GetTextNomeUsuario()
        {
            return this.txtNome;
        }

        #endregion

        #region Eventos
        private void btnLogar_Click(object sender, EventArgs e)
        {
            Usuario user = indexarDados();
            //verifica a consistencia dos dados
            if (ValidadorDTO.ValidateWarningAll(user))
            {
                //tenta fazer Login
                IsLogin = action.Login(user.Nome, user.Senha);

                if (IsLogin)
                {
                    this.UserName = user.Nome;
                    this.Password = user.Senha;
                    this.IsCancel = false;
                    //padrao eh true
                    if (this.DisposeOnLogin)
                        this.Dispose();

                    else if (this.IsHideOnLogin)
                        this.Hide();

                    //else nao faz nada else
                }
                else
                {
                    XMessageIts.Advertencia("Usuário ou senha inválido");
                    if (!string.IsNullOrEmpty(this.UserName))
                        this.txtSenha.Focus();
                    else
                        this.txtNome.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.IsCancel = true;
                this.Dispose();
            }
        }

        private void XFrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(null, null);

            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
            {
                //Chame a tela para procurar ClienteIts
                btnLogar_Click(null, null);

            }

        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrWhiteSpace(txtNome.Text) && String.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    txtSenha.Focus();
                }
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrWhiteSpace(txtNome.Text) && !String.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    btnLogar_Click(null, null);
                }
            }

        }

        private void btnActionBtn_Click(object sender, EventArgs e)
        {
            if (ActionBtn != null)
                ActionBtn.DynamicInvoke();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshClockDate();
        }

        private void XFrmLogin_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            if (this.CleanOnStart)
            {
                this.txtNome.Text = "";
                this.txtSenha.Text = "";
            }
        }

        private void XFrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //se eu cliquei em fechar e tem campo vazio vou cancelar o login
            if (IsLogin == false)
                this.IsCancel = true;
        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            var op = openFileDialog1.ShowDialog();

            if (op == DialogResult.OK)
            {

                this.panelControl1.ContentImage = ImageUtilIts.GetImageFromFile(openFileDialog1.FileName);
                //apaga se existir
                if (File.Exists(PATH_BACKGROUND))
                    File.Delete(PATH_BACKGROUND);
                this.panelControl1.ContentImage.Save(PATH_BACKGROUND);
                this.panelControl1.Refresh();
            }
        }

        #endregion Eventos

        #region Classe interna

        /// <summary>
        /// Classe para uso interno no Form
        /// </summary>
        internal class Usuario
        {
            [Required]
            [StringLength(50, MinimumLength = 1)]
            public String Nome { get; set; }

            [Required]
            [StringLength(40, MinimumLength = 1)]
            public String Senha { get; set; }

            [Required]
            public DateTime DataInclusao { get; set; }

            public Usuario(string nome, string senha)
            {
                this.Nome = nome;
                this.Senha = senha;
            }
        }


        #endregion

        #region Eventos para mover a janela

        private void panelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = true;
            mValX = e.X;
            mValY = e.Y;
        }

        private void panelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = false;
        }

        private void panelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove)
                this.SetDesktopLocation(MousePosition.X - mValX, MousePosition.Y - mValY);
        }

        #endregion


    }
}

