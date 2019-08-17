using System;
using System.Windows.Forms;
using ITSolution.Framework.Arquivos;
using System.Text;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Framework.Beans.ContextUtil
{
    /// <summary>
    /// Form para ilustrar a exibição do arquivo xml 
    /// Como sincronizar os dois Scrools ?
    /// </summary>
    public partial class XFrmXmlCompare : DevExpress.XtraEditors.XtraForm
    {
        private XFrmXmlCompare()
        {
            InitializeComponent();

            scintillaOriginal.ConfigureHighlightingXML();
            scintillaResult.ConfigureHighlightingXML();

            this.scintillaOriginal.MouseWheel += new MouseEventHandler(scintilla_MouseWheel);

        }

        public XFrmXmlCompare(string appConfig) : this()
        {
            this.tableLayoutPanel1.SetColumnSpan(this.scintillaOriginal, 2);
            this.scintillaOriginal.Text = appConfig;
            this.labelControl1.Visible = false;
            this.labelControl2.Visible = false;
            this.scintillaResult.Visible = false;
        }

        public XFrmXmlCompare(string xmlFile1, string xmlFile2) : this()
        {
            this.scintillaOriginal.Text = FileManagerIts.GetDataStringFile(xmlFile1);
            this.scintillaResult.Text = FileManagerIts.GetDataStringFile(xmlFile2);
        }

    

        private void barBtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                var data = FileManagerIts.GetDataFile(open.FileName);

                var sb = new StringBuilder();
                foreach (var item in data)
                {
                    sb.AppendLine(item);
                }
                scintillaOriginal.Text = FileManagerIts.GetDataStringFile(open.FileName);

            }
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {

                saveFile.ShowDialog();
            }
        }

        private void scintilla_MouseWheel(object sender, MouseEventArgs e)
        {
            scintillaOriginal.ScrollCaret();
            scintillaResult.ScrollCaret(); 
            /*scintillaOriginal.ScrollRange(e.Y, e.Y+10);
            scintillaResult.ScrollRange(e.X, e.X + 10);
            scintillaOriginal.ScrollCaret();
            scintillaResult.ScrollCaret();*/

        }

        private void scintillaOriginal_Move(object sender, EventArgs e)
        {
           
        }
    }
}

