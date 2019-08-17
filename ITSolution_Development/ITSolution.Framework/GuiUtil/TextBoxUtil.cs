
using ITSolution.Framework.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class TextBoxUtil
    {
        private TextBox textBox;
        private string FocusGain;
        private string FocusLost;
        public bool ControlFocusActived { get; set; }

        /// <summary>
        ///Adiciona uma ação de entrada e saída no campo de texto com CPF de entrada "" e saida 0,00
        /// </summary>
        /// <param name="textEdit"></param>
        /// <param name="focusGain"></param>
        /// <param name="focusLost"></param>
        public TextBoxUtil(TextBox textBox)
        {
            this.textBox = textBox;
            this.FocusGain = "";
            this.FocusLost = "0,00";
            this.textBox.RightToLeft = RightToLeft.Yes;

        }
        
        /// <summary>
        ///Adiciona uma ação de entrada e saída no campo de texto
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="focusGain"></param>
        /// <param name="focusLost"></param>
        public TextBoxUtil(TextBox textBox, string focusGain = null, string focusLost = null)
        {
            this.textBox = textBox;
            this.FocusGain = focusGain;
            this.FocusLost = focusLost;

        }
       
        /// <summary>
        /// Chamado ao entrar no campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextGotFocus(object sender, EventArgs e)
        {
            if (FocusGain == null) return;

            string text = textBox.Text;

            if (text.Equals(FocusLost) || text.Equals("0,0") || text.Equals("0"))
            {
                textBox.Text = FocusGain;
            }
            textBox.SelectAll();

        }

        /// <summary>
        /// Chamado quando sair do campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextLostFocus(object sender, EventArgs e)
        {
            if (FocusLost == null) return;
            string text = textBox.Text;
            Decimal value = ParseUtil.ToDecimal(text);

            if (value == 0 || String.IsNullOrWhiteSpace(textBox.Text) || textBox.Text.Equals(FocusGain))
            {
                textBox.Text = FocusLost;

            }
            else
            {
                textBox.Text = value.ToString("N2");

            }
        }

        private void TextValueChanged(object sender, EventArgs e)
        {
            decimal total = 0;

            total = ParseUtil.ToDecimal(textBox.Text);

            if (total < 0)
            {
                this.textBox.ForeColor = Color.Red;
            }
            else
            {
                this.textBox.ForeColor = Color.Black;

            }
        }

        public void AddControlFocus()
        {
            if (!ControlFocusActived)
            {
                this.ControlFocusActived = false;
                //usando o delegate
                textBox.GotFocus += new EventHandler(TextGotFocus);
                textBox.LostFocus += new EventHandler(TextLostFocus);
                textBox.TextChanged += new EventHandler(TextValueChanged);

            }
        }
    }
}
