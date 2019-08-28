using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.BarCode;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Components
{
    /// <summary>
    /// Cria um campo personalizado para código de barras
    /// </summary>
    public partial class TextCodigoBarras : TextEdit
    {
        public Decimal Quantidade
        {
            get
            {
                string txtCodBar = "" + this.Text;
                var split = txtCodBar.Split('*');
                Decimal qtde = 1;

                if (txtCodBar.Contains("*") && split.Length > 1)
                    qtde = ParseUtil.ToDecimal(split[0]);

                return qtde;
            }

        }
        public string CodigoBarras
        {
            get
            {
                string txtCodBar = this.Text;
                var split = txtCodBar.Split('*');

                if (txtCodBar.Contains("*") && split.Length > 1)
                {
                    txtCodBar = split[1];
                }
                else if (split.Length > 0)
                {
                    txtCodBar = split[0];
                }

                return txtCodBar;
            }
        }

        /// <summary>
        /// Bloquear os caracteres informados para que não sejam inseridos no campo
        /// </summary>
        /// <param name="caracteres"></param>
        public char[] CaracteresRestritos { get; set; }

        public TextCodigoBarras()
                : base()
        {

            // 
            // txtCodigoBarras
            // 

            this.Text = "0000000000";
            this.EditValue = "0000000000";
            this.Name = "txtCodigoBarras";
            this.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Properties.Appearance.Options.UseFont = true;
            this.Properties.Appearance.Options.UseTextOptions = true;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //We moved the TouchUIMode from the UserLookAndFeel class. 
            //If you need to enable\disable this mode for the entire application, 
            //use the static WindowsFormsSettings.TouchUIMode property.
            //this.Properties.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;

            this.Properties.MaxLength = 50;
            this.Size = new Size(421, 40);
            this.CaracteresRestritos = new char[] { };
            this.Enter += new System.EventHandler(CodigoBarras_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoBarras_KeyDown);
            this.EditValueChanging += new ChangingEventHandler(this.CodigoBarras_EditValueChanging);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoBarrasProduto_KeyPress);

            createToolTip();

        }

        private void createToolTip()
        {
            this.ToolTip = "Código de Barras do Produto";

            //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form));
            EAN13Generator eaN13Generator2 = new EAN13Generator();
            SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();

            //toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            //toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Código de Barras do Produto";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Utilize o leitor de código de barras ou faça uma pesquisa manual pelos critérios " +
    "das colunas da tabela.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.SuperTip = superToolTip2;
        }

        private void CodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            //O Evento KeyDown possui um atraso 
            //A cada tecla pressionada ele reconhece o novo caracter na proximo ocorrencia
            //Ex: Texto Atual = 1
            //Apos digitado um digito qualquer por ex *
            //O conteudo do texto para o evento ainda é igual = 1
            //Na proxima ocorrencia de um digito qualquer a string sera = 1*
            //Considerando que tenha outro digito
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = false;
                return;
            }
            else if (e.KeyCode == Keys.Multiply && this.Text.Contains("*") ||
                e.KeyCode == Keys.Decimal && this.Text.Contains(","))
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
                case Keys.Enter:
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
                //atencao ao asterico "*"
                case Keys.Multiply:
                //atencao ao virgula ","
                case Keys.Decimal:
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

        private void CodigoBarras_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
            if (this.Text.Equals("0000000000"))
                this.Text = "";
        }

        private void CodigoBarras_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //cancela o evento no campo para nao iniciar com * ou ,
            if (this.Text.StartsWith("*") || this.Text.StartsWith(","))
            {
                e.Cancel = true;
            }
        }

        private void CodigoBarrasProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //cancela o evento no campo do codigo das teclas de atalho
            foreach (char caracter in this.CaracteresRestritos)
            {
                if (e.KeyChar == caracter)
                    //cancela o evento
                    e.Handled = true;
            }
        }

    }
}
