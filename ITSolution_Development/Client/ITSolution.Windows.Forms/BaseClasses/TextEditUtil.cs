
using DevExpress.XtraEditors;
using ITSolution.Framework.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class TextEditUtil
    {
        private TextEdit textEdit;
        private Color oldColor;

        public string FocusGain { get; set; }
        public string FocusLost { get; set; }
        public bool ControlFocusActived { get; set; }

        /// <summary>
        /// Casas Decimais do campo de texto
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        ///Adiciona uma ação de entrada e saída no campo de texto com valor de entrada "" e saida 0,00
        /// </summary>
        /// <param name="textEdit"></param>
        /// <param name="focusGain"></param>
        /// <param name="focusLost"></param>
        public TextEditUtil(TextEdit textEdit)
        {
            this.textEdit = textEdit;
            this.FocusGain = "";
            this.FocusLost = "0,00";
            this.Scale = 2;
            this.textEdit.Properties.Mask.EditMask = "n";
            this.textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        }

        ///  <summary>
        /// Adiciona uma ação de entrada e saída no campo de texto com valor de entrada "" e saida 0,00
        ///  </summary>
        ///  <param name="textEdit"></param>
        /// <param name="scale"></param>
        public TextEditUtil(TextEdit textEdit, int scale = 0)
        {
            this.textEdit = textEdit;
            this.FocusGain = "";
            this.FocusLost = "0,00";
            this.Scale = scale;

        }

        ///  <summary>
        /// Adiciona uma ação de entrada e saída no campo de texto com valor de entrada "" e saida 0,00
        ///  </summary>
        ///  <param name="textEdit"></param>
        /// <param name="focusLost"></param>
        /// <param name="scale"></param>
        public TextEditUtil(TextEdit textEdit, string focusLost = "", int scale = 0)
        {
            this.textEdit = textEdit;
            this.FocusGain = "";
            this.FocusLost = focusLost;
            this.Scale = scale;

        }

        /// <summary>
        ///Adiciona uma ação de entrada e saída no campo de texto
        /// </summary>
        /// <param name="textEdit"></param>
        /// <param name="focusGain"></param>
        /// <param name="focusLost"></param>
        public TextEditUtil(TextEdit textEdit, string focusGain = null, string focusLost = null)
        {
            this.textEdit = textEdit;
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
            textEdit.SelectAll();

            string text = textEdit.Text;

            if (text.Equals(FocusLost) || text.Equals("0")
                || text.Equals("0,0")
                || text.Equals("0,00")
                || text.Equals("0,000"))
            {
                textEdit.Text = null;
                textEdit.Refresh();
            }
        }

        /// <summary>
        /// Chamado quando sair do campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextLostFocus(object sender, EventArgs e)
        {
            if (FocusLost == null) return;

            string text = textEdit.Text;
            if (string.IsNullOrWhiteSpace(text))
                this.textEdit.Text = "0,00";
            else
            {
                Decimal value = ParseUtil.ToDecimal(text);

                if (value == 0 || String.IsNullOrWhiteSpace(textEdit.Text) || textEdit.Text.Equals(FocusGain))
                {
                    textEdit.Text = FocusLost;
                }
                else
                {
                        if (Scale < 0)
                        textEdit.Text = value.ToString("n0");
                    else if (Scale > 0)
                        textEdit.Text = value.ToString("n" + Scale);
                    //default 3 casas
                    else
                        textEdit.Text = value.ToString("n3");
                }
            }
        }
        
        /// <summary>
        /// Seta de vermelho quando o valor do campo de texto for negativo ao sair do campo
        /// </summary>
        /// <param name="oldColor"></param>Antiga cor que o campo
        public void CustomizeValueNegative(Color oldColor)
        {
            this.oldColor = oldColor;
            textEdit.EditValueChanged += new EventHandler(TextValueChanged);
        }

        private void TextValueChanged(object sender, EventArgs e)
        {
            string text = textEdit.Text;
            decimal total = ParseUtil.ToDecimal(text);

            if (total < 0)
                this.textEdit.ForeColor = Color.Red;
            else
            {
                if (oldColor != Color.Black)
                    this.textEdit.ForeColor = oldColor;

            }
        }

        private void TextValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //cancela o evento no campo para nao iniciar com * ou ,
            if (this.textEdit.Text.StartsWith(","))
            {
                e.Cancel = true;
            }
        }

        public void CustomizeNumberField()
        {
            //usando o delegate
            this.textEdit.GotFocus += new EventHandler(TextGotFocus);
            this.textEdit.LostFocus += new EventHandler(TextLostFocus);

            //this.textEdit.EditValueChanging += new ChangingEventHandler(TextValueChanging);
            //this.textEdit.KeyDown += new KeyEventHandler(CheckKeyDown);
            //this.textEdit.KeyPress += new KeyPressEventHandler(CheckKeyPress);

        }

        public void AddGotFocus()
        {
            textEdit.GotFocus += new EventHandler(FocoEntrada);
        }

        /// <summary>
        /// Chamado ao entrar no campo para selecionar o texto existente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocoEntrada(object sender, EventArgs e)
        {
            textEdit.SelectAll();
        }

        /*   Controle de numeros no campo de texto
       private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.textEdit.Text.Contains(",") ||this.textEdit.Text.Contains(","))
                    if (e.KeyChar == ',' && !isDecimal|| e.KeyChar == '.' )
                //cancela o evento
                e.Handled = true;
            Antes 
            //Se a tecla digitada não for número e nem backspace e nem virgula
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            } 
        */

        /// <summary>
        /// Permite somente número do teclado alfa e alfa númerico
        /// Bloquea o controle de inserção pelo Ctrl + V = Colar
        /// O teclado numerico tbm é bloqueado (NumPad0 a 9)
        ///Fonte Base 
        ///http://www.vcskicks.com/numbers_only_textbox.php
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckKeyDown(object sender, KeyEventArgs e)
        {

            //O Evento KeyDown possui um atraso 
            //A cada tecla pressionada ele reconhece o novo caracter na proximo ocorrencia
            //Ex: Texto Atual = 1
            //Apos digitado um digito qualquer por ex ,
            //O conteudo do texto para o evento ainda é igual = 1
            //Na proxima ocorrencia de um digito qualquer a string sera = 1,
            //Considerando que tenha outro digito
            if (e.KeyCode == Keys.Decimal && this.textEdit.Text.Contains(","))
            {
                //cancele o evento
                e.SuppressKeyPress = true;
                return;
            }

            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                //todos os case sao permitidos
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                //atencao ao virgula ","
                case Keys.Decimal:
                    //permita o evento
                    e.SuppressKeyPress = false;
                    return;
                default:
                    break;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);


            if (!modifier && nonNumber)
                //cancela o evento
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (char.IsDigit(pasteText[i]))
                        strippedText += pasteText[i].ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextEdit me = (TextEdit)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }
    }
}
