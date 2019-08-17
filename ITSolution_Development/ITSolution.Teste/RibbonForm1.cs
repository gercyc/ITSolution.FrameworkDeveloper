using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Xml.Linq;
using ITSolution.Framework.ConnectionFactory;

namespace ITSolution.Teste
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void barBtnCarregarXml_ItemClick(object sender, ItemClickEventArgs e)
        {
            //gridControl1.DataSource = ConnectionFactoryIts.GetDataSources();

            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(op.FileName);
                gridControl1.DataSource = ds;
            }
        }
    }
}