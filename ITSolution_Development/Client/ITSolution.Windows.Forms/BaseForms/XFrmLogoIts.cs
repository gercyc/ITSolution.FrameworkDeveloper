using System;
using System.Windows.Forms;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Framework.Beans.Forms
{
    /// <summary>
    /// Um form que ficara sempre aberto no form menu
    /// </summary>
    public partial class XFrmLogoIts : DevExpress.XtraEditors.XtraForm
    {
        public XFrmLogoIts()
        {
            InitializeComponent();
            FormsUtil.AddShortcutEscapeOnDispose(this);

        }


        private void XFrmLogoIts_Shown(object sender, EventArgs e)
        {
        }


        #region Form move control

        private bool mouseMove;
        private int mValX;
        private int mValY;


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

        private void labelControl4_MouseEnter(object sender, EventArgs e)
        {
            this.lblWebsite.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Underline);
            this.lblWebsite.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
        }

        private void lblWebsite_MouseLeave(object sender, EventArgs e)
        {
            this.lblWebsite.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblWebsite.Appearance.ForeColor = System.Drawing.Color.Black;
        }

        private void hyperLblSiteIte_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://"+ e.Text);
            //WebBrowser oWebBrowser = new WebBrowser(); // Instancia o Browser
            //oWebBrowser.Navigate("http://" + e.Text); // Acessa a URL do fórum
            //oWebBrowser.Document.GetElementById("subject").SetAttribute("value", "SEU VALOR"); // muda o texto do input
            //oWebBrowser.Document.InvokeScript("eval", new object[] { "envia()" }); // invoca a função envia() do html
        }
    }
}