using System;
using System.Windows.Forms;
using ITSolution.Framework.GuiUtil;
using System.IO;
using ITSolution.Framework.Arquivos;

namespace ITSolution.Framework.Beans.Forms
{
    public partial class XFrmHighlighting : DevExpress.XtraEditors.XtraForm
    {
        private string file;

        public XFrmHighlighting(string textOrFile, ScintillaNET.Lexer lexer)
        {
            InitializeComponent();

            if (File.Exists(textOrFile))
            {
                this.scintilla.Text = FileManagerIts.GetDataStringFile(textOrFile);
                this.file = textOrFile;
            }
            else
                this.scintilla.Text = textOrFile;

            scintilla.ConfigureLexer(lexer);
            
            
        }

        public bool IsTextSave { get; set; }

        private void barBtnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (File.Exists(this.file))
            {
                this.IsTextSave = FileManagerIts.OverWriteOnFile(this.file, scintilla.Text) ;
            }
            else
            {
                using (SaveFileDialog saveFile = new SaveFileDialog())
                {
                    saveFile.ShowDialog();
                }
            }
            this.Dispose();
        }
    }
}