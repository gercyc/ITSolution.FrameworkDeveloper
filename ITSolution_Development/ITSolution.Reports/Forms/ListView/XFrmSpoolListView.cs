using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Reports.DaoManager;
using ITSolution.Reports.Repositorio;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;

namespace ITSolution.Reports.Forms.ListView
{
    public partial class XFrmSpoolReport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XFrmSpoolReport()
        {
            InitializeComponent();
            btnRemoveSpool.Enabled = false;
        }

        private void fillGrid()
        {
            using (var ctx = new ReportContext())
            {
                var query = from p in ctx.ReportSpools
                            select
                            new
                            {
                                p.IdSpool,
                                p.GenerateTime,
                                p.ReportName,
                                ReportSpoolImage = new byte[] { 0 }
                            };

                this.Invoke(new MethodInvoker(delegate
                {
                    gridControlRelatorios.DataSource = query.ToList().OrderByDescending(s => s.GenerateTime);

                }));
            }

        }
 

        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await Task.Run(() => fillGrid());
        }

        private void btnVisualizarImpressao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int relat = (int)gridViewRelatorios.GetFocusedRowCellValue("IdSpool");
            new ReportSpoolDaoManager().GerarRelatorioFromSpool(relat, TypeGeracaoSpool.PreVisualizar);

        }
        private void btnSalvarPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int relat = (int)gridViewRelatorios.GetFocusedRowCellValue("IdSpool");
            if (relat != 0)
                new ReportSpoolDaoManager().GerarRelatorioFromSpool(relat, TypeGeracaoSpool.ExportarParaPdf);
        }

        private void btnSalvarXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int relat = (int)gridViewRelatorios.GetFocusedRowCellValue("IdSpool");
            if (relat != 0)
                new ReportSpoolDaoManager().GerarRelatorioFromSpool(relat, TypeGeracaoSpool.ExportarParaExcel);
        }

        private void XFrmSpoolRel_Shown(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        private void btnRemoveSpool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gridViewRelatorios.IsSelectRow())
            {
                int relat = (int)gridViewRelatorios.GetFocusedRowCellValue("IdSpool");
                new ReportSpoolDaoManager().RemoveRelatorioFromSpool(relat);
                btnRefresh_ItemClick(null, null);
            }
            
        }

        private void gridViewRelatorios_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewRelatorios.IsSelectRow())
            {
                btnRemoveSpool.Enabled = true;
            }
        }
    }
}