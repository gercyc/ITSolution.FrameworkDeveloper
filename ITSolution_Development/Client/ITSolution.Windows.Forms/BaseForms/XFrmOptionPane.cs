using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmOptionPane : DevExpress.XtraEditors.XtraForm
    {
        public static bool Cancel { get; private set; }
        public int MaxLengthTextInput { get; private set; }
        /// <summary>
        /// Exibe um form com text area
        /// </summary>
        private XFrmOptionPane()
        {
            InitializeComponent();
            this.ActiveControl = txtInput;
            this.txtInput.Text = "";
            this.txtInput.Focus();

        }

        /// <summary>
        /// Exibe e retorna uma string
        /// </summary>
        /// <param name="title"></param>Titulo da janela
        /// <param name="message"></param>Mensagem informativa do label acima do campo de texto
        /// <param name="content"></param>Conteudo do campo de texto
        /// <returns>A string digitada na caixa de combinação ou null se cancelado</returns>
        public static string ShowInputDialog(string title = "Mensagem", string message = "Digite um nome:",
            string content = "", int maxLenght = 0)
        {
            XFrmOptionPane.Cancel = false;
            XFrmOptionPane input = new XFrmOptionPane();
            input.panel2.Visible = false;

            input.Size = new Size(640, 175);
            input.Text = title;
            input.lblMsg.Text = message;
            input.txtInput.Text = content;

            //limite de texto
            if (maxLenght > 0)
            {
                input.MaxLengthTextInput = maxLenght;
                input.txtInput.Properties.MaxLength = maxLenght;
            }
            //Dispara a Thread
            input.ShowDialog();
            //retorna o texto
            return input.txtInput.Text;

        }

        /// <summary>
        /// Exibe um text area
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="title"></param>
        public static void ShowTextArea(string title = "Mensagem", params string[] messages)
        {
            XFrmOptionPane frm = new XFrmOptionPane();
            //frm.Size = new Size(736, 393);
            frm.panel1.Visible = false;
            frm.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.Text = title;

            foreach (var m in messages)
            {
                if (m != null)
                    frm.rTextBoxArea.AppendText(m.ToString() + "\n");
            }
            //Dispara a Thread
            frm.ShowDialog();
        }

        /// <summary>
        /// Exibe um text area
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista"></param>
        /// <param name="title"></param>
        public static void ShowListTextArea<T>(List<T> lista, string title = "Mensagem")
        {
            if (lista == null)
                lista = new List<T>();
            XFrmOptionPane input = new XFrmOptionPane();
            //input.Size = new Size(621, 313);
            input.panel1.SendToBack();
            input.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            input.Text = title;

            foreach (var item in lista)
            {
                if (item != null)
                    input.rTextBoxArea.AppendText(item.ToString() + "\n");
            }
            //Dispara a Thread
            input.ShowDialog();
        }


        private void XFrmOptionPane_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtInput.Text))
            {
                XMessageIts.Advertencia("Texto inválido");
                txtInput.Focus();
            }
            else if (MaxLengthTextInput != 0 && txtInput.Text.Length > MaxLengthTextInput)
            {
                XMessageIts.Advertencia("Limite de caracteres não pode ser superior a " + MaxLengthTextInput, "Aviso");
                txtInput.Focus();
            }
            else
                this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {
                var op = XMessageIts.Confirmacao("A mensagem será descartada ok ?", "Atenção");

                if (op == DialogResult.No)
                {
                    return;
                }
            }
            txtInput.Text = "";
            Cancel = true;
            this.Dispose();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }
    }
}