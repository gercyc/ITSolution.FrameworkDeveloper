using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace ITSolution.Framework.Mensagem
{
    public class MessageBoxBlack : DevExpress.XtraEditors.XtraForm
    {
        private const int CS_DROPSHADOW = 0x00020000;
        private Panel plHeader = new Panel();
        private Panel plFooter = new Panel();
        private Panel plIcon = new Panel();
        private PictureBox picIcon = new PictureBox();
        private FlowLayoutPanel flpButtons = new FlowLayoutPanel();
        private Label lblTitle;
        private Label lblMessage;
        private List<Button> _buttonCollection = new List<Button>();
        private DialogResult _buttonResult = new DialogResult();
        private Timer _timer;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        private MessageBoxBlack()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Width = 400;

            lblTitle = new Label();
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new System.Drawing.Font("Tahoma", 18);
            lblTitle.Dock = DockStyle.Top;

            lblTitle.Height = 50;

            lblMessage = new Label();
            lblMessage.ForeColor = Color.White;//tava essa Segoe UI
            lblMessage.Font = new System.Drawing.Font("Tahoma", 10);
            lblMessage.Dock = DockStyle.Fill;

            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Dock = DockStyle.Fill;

            plHeader.Dock = DockStyle.Fill;
            plHeader.Padding = new Padding(20);
            plHeader.Controls.Add(lblMessage);
            plHeader.Controls.Add(lblTitle);

            plFooter.Dock = DockStyle.Bottom;
            plFooter.Padding = new Padding(20);
            plFooter.BackColor = Color.FromArgb(37, 37, 38);
            plFooter.Height = 80;
            plFooter.Controls.Add(flpButtons);

            picIcon.Width = 48;
            picIcon.Height = 48;
            picIcon.Location = new Point(30, 50);

            plIcon.Dock = DockStyle.Left;
            plIcon.Padding = new Padding(20);
            plIcon.Width = 70;
            plIcon.Controls.Add(picIcon);

            this.Controls.Add(plHeader);
            this.Controls.Add(plIcon);
            this.Controls.Add(plFooter);
        }

        private static MessageBoxBlack createMsgBox(string message, string title,
         Buttons buttons, Icone icon, AnimateStyle style)
        {
            var _msgBox = new MessageBoxBlack();
            _msgBox.lblMessage.Text = message ;
            _msgBox.lblTitle.Text = title;
            _msgBox.Height = 0;

            if (title == null)
                title = "Mensagem";

            MessageBoxBlack.InitButtons(_msgBox, buttons);
            MessageBoxBlack.InitIcon(_msgBox, icon);

            _msgBox._timer = new Timer();
            Size formSize = MessageBoxBlack.MessageSize(message,_msgBox);

            switch (style)
            {
                case AnimateStyle.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _msgBox._timer.Interval = 1;
                    _msgBox._timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case AnimateStyle.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _msgBox._timer.Interval = 20;
                    _msgBox._timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case AnimateStyle.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _msgBox._timer.Tag = new AnimateMsgBox(formSize, style);
                    _msgBox._timer.Interval = 1;
                    break;
            }

            _msgBox._timer.Tick += _msgBox.timer_Tick;
            _msgBox._timer.Start();
            return _msgBox;
        }

        public static void Advertencia(string message,string title=null)
        {
            MessageBoxBlack _msgBox = createMsgBox(message, title, Buttons.OK, Icone.Exclamation, AnimateStyle.FadeIn);

            _msgBox.ShowDialog();

            MessageBeep(0);
        }

        public static void Show(string message)
        {
            MessageBoxBlack _msgBox = createMsgBox(message, "Mensagem", Buttons.OK, Icone.Info, AnimateStyle.FadeIn);

            _msgBox.ShowDialog();

            MessageBeep(0);
        }
        
        public static DialogResult Confirmation(string message,string title = null)
        {
            return Show(message, title, Buttons.OKCancel, Icone.Question, AnimateStyle.FadeIn);
        }

        public static void Show(string message, string title)
        {
            MessageBoxBlack _msgBox = createMsgBox(message, title, Buttons.OK, Icone.Info, AnimateStyle.FadeIn);
            _msgBox.ShowDialog();

            MessageBeep(0);

            //_msgBox = new MessageBoxBlack();
            //_msgBox.lblMessage.Text = message;
            //_msgBox.lblTitle.Text = title;
            //_msgBox.Size = MessageBoxBlack.MessageSize(message);
            //_msgBox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, Buttons buttons = Buttons.OK)
        {

            MessageBoxBlack _msgBox = createMsgBox(message, title, Buttons.OK, Icone.Info, AnimateStyle.FadeIn);

            _msgBox.plIcon.Hide();

            _msgBox.ShowDialog();

            //_msgBox = new MessageBoxBlack();
            //_msgBox.lblMessage.Text = message;
            //_msgBox.lblTitle.Text = title;
            //_msgBox.plIcon.Hide();

            //MessageBoxBlack.InitButtons(buttons);

            //_msgBox.Size = MessageBoxBlack.MessageSize(message);
            //_msgBox.ShowDialog();
            MessageBeep(0);

            return _msgBox._buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, Icone icon)
        {
            MessageBoxBlack _msgBox = createMsgBox(message, title, buttons, icon, AnimateStyle.FadeIn);
            _msgBox.ShowDialog();

            //_msgBox = new MessageBoxBlack();
            //_msgBox.lblMessage.Text = message;
            //_msgBox.lblTitle.Text = title;

            //MessageBoxBlack.InitButtons(buttons);
            //MessageBoxBlack.InitIcon(icon);

            //_msgBox.Size = MessageBoxBlack.MessageSize(message);
            //_msgBox.ShowDialog();

            MessageBeep(0);

            return _msgBox._buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, Icone icon, AnimateStyle style)
        {
            MessageBoxBlack _msgBox = createMsgBox(message, title, buttons, icon, style);
            _msgBox.ShowDialog();

            return _msgBox._buttonResult;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!this.IsDisposed)
            {

                Timer timer = (Timer) sender;
                AnimateMsgBox animate = (AnimateMsgBox) timer.Tag;

                switch (animate.Style)
                {
                    case AnimateStyle.SlideDown:
                        if (this.Height < animate.FormSize.Height)
                        {
                            this.Height += 17;
                            this.Invalidate();
                        }
                        else
                        {
                            _timer.Stop();
                            _timer.Dispose();
                        }
                        break;

                    case AnimateStyle.FadeIn:
                        if (this.Opacity < 1)
                        {

                            this.Opacity += 0.1;
                            this.Invalidate();
                        }
                        else
                        {
                            _timer.Stop();
                            _timer.Dispose();
                        }
                        break;

                    case AnimateStyle.ZoomIn:
                        if (this.Width > animate.FormSize.Width)
                        {
                            this.Width -= 17;
                            this.Invalidate();
                        }
                        if (this.Height > animate.FormSize.Height)
                        {
                            this.Height -= 17;
                            this.Invalidate();
                        }
                        break;
                }
            }
        }

        private static void InitButtons(MessageBoxBlack _msgBox, Buttons buttons)
        {
            switch (buttons)
            {
                case Buttons.AbortRetryIgnore:
                    _msgBox.InitAbortRetryIgnoreButtons();
                    break;

                case Buttons.OK:
                    _msgBox.InitOKButton();
                    break;

                case Buttons.OKCancel:
                    _msgBox.InitOKCancelButtons();
                    break;

                case Buttons.RetryCancel:
                    _msgBox.InitRetryCancelButtons();
                    break;

                case Buttons.YesNo:
                    _msgBox.InitYesNoButtons();
                    break;

                case Buttons.YesNoCancel:
                    _msgBox.InitYesNoCancelButtons();
                    break;
            }

            foreach (Button btn in _msgBox._buttonCollection)
            {
                btn.ForeColor = Color.FromArgb(170, 170, 170);
                btn.Font = new System.Drawing.Font("Tahoma", 8);
                btn.Padding = new Padding(3);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 35;
                btn.Width = 90;
                btn.FlatAppearance.BorderColor = Color.FromArgb(99, 99, 98);

                _msgBox.flpButtons.Controls.Add(btn);
            }
        }

        private static void InitIcon(MessageBoxBlack _msgBox, Icone icon)
        {
            switch (icon)
            {
                case Icone.Application:
                    _msgBox.picIcon.Image = SystemIcons.Application.ToBitmap();
                    break;

                case Icone.Exclamation:
                    _msgBox.picIcon.Image = SystemIcons.Exclamation.ToBitmap();
                    break;

                case Icone.Error:
                    _msgBox.picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;

                case Icone.Info:
                    _msgBox.picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;

                case Icone.Question:
                    _msgBox.picIcon.Image = SystemIcons.Question.ToBitmap();
                    break;

                case Icone.Shield:
                    _msgBox.picIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;

                case Icone.Warning:
                    _msgBox.picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        private void InitAbortRetryIgnoreButtons()
        {
            Button btnAbort = new Button();
            btnAbort.Text = "Abort";
            btnAbort.Click += ButtonClick;

            Button btnRetry = new Button();
            btnRetry.Text = "Retry";
            btnRetry.Click += ButtonClick;

            Button btnIgnore = new Button();
            btnIgnore.Text = "Ignore";
            btnIgnore.Click += ButtonClick;

            this._buttonCollection.Add(btnAbort);
            this._buttonCollection.Add(btnRetry);
            this._buttonCollection.Add(btnIgnore);
        }

        private void InitOKButton()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            this._buttonCollection.Add(btnOK);
        }

        private void InitOKCancelButtons()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;


            this._buttonCollection.Add(btnOK);
            this._buttonCollection.Add(btnCancel);
        }

        private void InitRetryCancelButtons()
        {
            Button btnRetry = new Button();
            btnRetry.Text = "OK";
            btnRetry.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;


            this._buttonCollection.Add(btnRetry);
            this._buttonCollection.Add(btnCancel);
        }

        private void InitYesNoButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Sim";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "Não";
            btnNo.Click += ButtonClick;


            this._buttonCollection.Add(btnYes);
            this._buttonCollection.Add(btnNo);
        }

        private void InitYesNoCancelButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Abort";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "Retry";
            btnNo.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;

            this._buttonCollection.Add(btnYes);
            this._buttonCollection.Add(btnNo);
            this._buttonCollection.Add(btnCancel);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Abort":
                    _buttonResult = DialogResult.Abort;
                    break;

                case "Retry":
                    _buttonResult = DialogResult.Retry;
                    break;

                case "Ignore":
                    _buttonResult = DialogResult.Ignore;
                    break;

                case "OK":
                    _buttonResult = DialogResult.OK;
                    break;

                case "Cancel":
                    _buttonResult = DialogResult.Cancel;
                    break;

                case "Yes":
                    _buttonResult = DialogResult.Yes;
                    break;

                case "No":
                    _buttonResult = DialogResult.No;
                    break;
            }

            this.Dispose();
        }

        private static Size MessageSize(string message,MessageBoxBlack _msgBox)
        {
            Graphics g = _msgBox.CreateGraphics();
            int width = 450;
            int height = 230;
            SizeF size = g.MeasureString(message, new System.Drawing.Font("Tahoma", 10));

            if (message.Length < 40)
            {
                if ((int)size.Width > 350)
                {
                    width = (int)size.Width;
                }
            }
            else if (message.Length < 100 && message.Length > 40)
            {
                string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                int lines = groups.Length + 1;
                width = 560;
                height += (int)(size.Height + 5) * lines;
            }
            else
            {
                string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                int lines = groups.Length + 1;
                width = 880;
                height += (int)(size.Height + 10) * lines;
            }
            return new Size(width, height);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Color.FromArgb(0, 151, 251));

            g.DrawRectangle(pen, rect);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MessageBoxBlack
            // 
            this.ClientSize = new System.Drawing.Size(371, 262);
            this.KeyPreview = true;
            this.Name = "MessageBoxBlack";
            this.Text = "Mensagem";
            this.ResumeLayout(false);

        }
    }


}
