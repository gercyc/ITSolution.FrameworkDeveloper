using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Reports.Repositorio;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.ConsultasSQL
{
    public partial class XFrmQueriesSQL : DevExpress.XtraEditors.XtraForm
    {
        public XFrmQueriesSQL()
        {
            InitializeComponent();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmWait.StartTask(loadQueries(), "Carregando consultas");
        }
        private async Task loadQueries()
        {
            using (var ctx = new ReportContext())
            {
                var result = await ctx.SqlQueryItsDao.FindAllAsync();

                gridControlQueries.DataSource = result;
                
            }
        }

        private void btnNewQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormsUtil.ShowDialog(new XFrmAddConsultaSQL());
        }

        private void btnEditQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedQuery = gridViewQueris.GetFocusedRow<SqlQueryIts>();
            if(selectedQuery != null)
            {
                FormsUtil.ShowDialog(new XFrmAddConsultaSQL(selectedQuery));
            }
        }

        private void btnRemoveQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (var ctx = new ReportContext())
                {
                    var selectedQuery = gridViewQueris.GetFocusedRow<SqlQueryIts>();

                    var op = XMessageIts.Confirmacao("Certeza que deseja excluir a consulta selecionada?!", "Confirmação");

                    if (op == DialogResult.Yes)
                    {
                        var resultDelete = ctx.SqlQueryItsDao.Delete(selectedQuery);
                        if (resultDelete)
                            XMessageIts.Mensagem("Consulta excluída com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }            
        }

        private void XFrmQueriesSQL_Shown(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }
    }
}