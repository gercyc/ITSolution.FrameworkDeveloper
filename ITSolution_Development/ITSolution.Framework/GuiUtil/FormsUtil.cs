using System;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class FormsUtil
    {
        public static void Run(Form form)
        {
            if (form != null && form.IsDisposed == false)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(form);
            }
        }

        public static void Maximized(Form form)
        {
            if (form != null)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        public static void Minimized(Form form)
        {
            if (form != null)
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public static void Normal(Form form)
        {
            if (form != null)
            {
                form.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// Exibe o formInvoke centralizado na tela e congela first instancia anterior da instancia chamada.
        /// </summary>
        /// <param colName="formInvoke"></param>
        /// 
        public static void Show(Form form)
        {
            if (form != null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
                form.Show();
            }

        }

        /// <summary>
        /// Exibe o formInvoke centralizado na tela e congela first instancia anterior da instancia chamada.
        /// </summary>
        /// <param colName="formInvoke"></param>
        /// 
        public static void ShowDialog(Form form)
        {
            if (form != null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
                form.ShowDialog();
            }

        }

        /// <summary>
        /// Exibe um form dentro do MdiForm
        /// </summary>
        /// <param name="form"></param>
        /// <param name="MdiForm"></param>
        public static void Show(Form form, Form MdiForm)
        {
            if (form != null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
                form.MdiParent = MdiForm;
                form.Show();
            }
        }

        /// <summary>
        /// Exibe um form dentro do MdiForm
        /// </summary>
        /// <param name="form"></param>
        /// <param name="MdiForm"></param>
        public static void ShowDialog(Form form, Form MdiForm)
        {
            if (form != null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
                form.MdiParent = MdiForm;
                form.ShowDialog();
            }

        }

        /// <summary>
        /// Habilita o form e foca o mesmo
        /// </summary>
        /// <param colName="formInvoke"></param>
        public static void ToFrontEnabled(Form form)
        {
            if (form != null)
            {
                form.Enabled = true;
                form.Activate();
                form.Focus();
                form.BringToFront();
            }
        }

        /// <summary>
        /// Desabilita e minimiza o form
        /// </summary>
        /// <param colName="formInvoke"></param>
        public static void ToBackDisabled(Form form)
        {
            if (form != null)
            {
                form.Enabled = true;
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public static int GetBitsPorPixel()
        {
            int c = Screen.PrimaryScreen.BitsPerPixel;
            return c;
        }

        public static int GetWidthScreen()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            return w;
        }

        public static int GetHeightScreen()
        {
            int h = Screen.PrimaryScreen.Bounds.Height;
            return h;
        }

        public static bool isFormDisposedOrNull(Form form)
        {
            if (form == null || form.IsDisposed)
            {
                return true;
            }
            return false;
        }

        private void shortCutScape(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (this.form != null && this.form.IsDisposed == false)
                    form.Dispose();
        }

        private void shortCutCtrlW(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W)
                if (this.form != null && this.form.IsDisposed == false)
                    form.Dispose();
        }

        /// <summary>
        /// Add uma atalho para Dispose pela tecla Escape do teclado
        /// </summary>
        /// <param name="form"></param>
        public static void AddShortcutEscapeOnDispose(Form form)
        {
            FormsUtil util = new FormsUtil();

            util.form = form;
            util.form.KeyDown += new KeyEventHandler(util.shortCutScape);
            util.form.KeyPreview = true;
        }

        /// <summary>
        /// Add uma atalho para Dispose pela tecla Escape do teclado
        /// </summary>
        /// <param name="form"></param>
        public static void AddShortcutCtrlWOnDispose(Form form)
        {
            FormsUtil util = new FormsUtil();

            util.form = form;
            util.form.KeyDown += new KeyEventHandler(util.shortCutCtrlW);
            util.form.KeyPreview = true;
        }

        private Form form;
    }
}
