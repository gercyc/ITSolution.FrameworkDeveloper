using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ITSolution.Framework.Mensagem
{
    /// <summary>
    /// Fundo transparente
    /// </summary>
    public partial class MessageBoxTick : DevExpress.XtraEditors.XtraForm
    {

        private static MessageBoxTick messageBox;
        private DialogResult dResult;
        private int timerValue;

        private MessageBoxTick()
        {
            InitializeComponent();

        }

        public static DialogResult Show(string message)
        {
            messageBox = new MessageBoxTick();
            messageBox.lblMessage.Text = message;
            messageBox.ShowDialog();

            return messageBox.dResult;
        }

        public static DialogResult Show(string message, string title)
        {
            messageBox = new MessageBoxTick();
            messageBox.Text = title;
            messageBox.lblMessage.Text = message;
            messageBox.ShowDialog();
            return messageBox.dResult;
        }

        public static DialogResult Show(string message, string title, int seconds, bool cancel = false)
        {
            messageBox = new MessageBoxTick();
            
            messageBox.timerValue = seconds;
            messageBox.Text = title;
            messageBox.lblMessage.Text = message;
            messageBox.lblMessage.Image = null;
            messageBox.btnOK.Visible = false;

            if (cancel)
                messageBox.btnCancel.Visible = true;
            else
                messageBox.btnCancel.Visible = false;
            messageBox.ShowDialog();

            return messageBox.dResult;
        }

        public static DialogResult Show(Exception ex, string message, string title)
        {
            messageBox = new MessageBoxTick();
            messageBox.Text = title;
            messageBox.btnCancel.Visible = false;
            messageBox.btnOK.Visible = false;
            messageBox.lblMessage.Text = ex.Message + ":"+message;
            messageBox.ShowDialog();
            return messageBox.dResult;
        }


        #region Eventos

        private void messageBoxTick_Paint(object sender, PaintEventArgs e)
        {

            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            messageBox.timer1.Stop();
            messageBox.timer1.Dispose();
            messageBox.dResult = DialogResult.OK;
            messageBox.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            messageBox.timer1.Stop();
            messageBox.timer1.Dispose();
            dResult = DialogResult.Cancel;
            messageBox.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerValue--;

            if (timerValue >= 0)
            {
                messageBox.lblTimer.Text = timerValue.ToString();
            }
            else
            {
                messageBox.timer1.Stop();
                messageBox.timer1.Dispose();
                messageBox.Dispose();
            }

        }


        #endregion

        private void MessageBoxTick_Load(object sender, EventArgs e)
        {
            //define um valor default
            if(messageBox.timerValue == 0)
                messageBox.timerValue = 5;

            messageBox.timer1.Interval = 1000;
            messageBox.timer1.Enabled = true;
            messageBox.timer1.Start();

            messageBox.lblTimer.Text = timerValue.ToString();

            if (messageBox.timerValue > 0)
            {
                messageBox.lblTimer.Visible = true;
            }
            else
            {
                messageBox.lblTimer.Visible = false;
                messageBox.timer1.Stop();
            }

        }
    }
}