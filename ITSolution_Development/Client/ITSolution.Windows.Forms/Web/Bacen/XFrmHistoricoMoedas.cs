using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ITSolution.Framework.Web.Bacen
{
    public partial class XFrmHistoricoMoedas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XFrmHistoricoMoedas()
        {
            InitializeComponent();
            dateEditInicio.DateTime = DataUtil.GetDataInicialDoMesAtual();
            dateEditFim.DateTime = DataUtil.GetDataFinalDoMesAtual();
        }

        #region Eventos Bar manager
        private void barBtnSalvarCotacao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmWait.ShowSplashScreen("Salvando moedas");
            var cotacoes = gridView1.GetItens<CotacaoMonetaria>();

            var manager = new MoedaDaoManager();

            foreach (var c in cotacoes)
            {
                manager.SaveCotacaoMonetaria(c);
            }
            XFrmWait.CloseSplashScreen();
        }

        private void barBtnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsEmpty)
            {
                XMessageIts.Mensagem("Nada a exportar !");
            }
            else
            {
                if (gridView1.DataSource != null)
                {
                    string excelName = "export_cambio_excel" + DataUtil.ToDateSql();
                    string xls = Path.Combine(FileManagerIts.DeskTopPath, excelName) + ".xlsx";

                    FileManagerIts.DeleteFile(xls);

                    gridControl1.ExportToXlsx(xls);
                    FileManagerIts.OpenFromSystem(xls);
                }
            }

        }

        private void barBtnExportarPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsEmpty)
            {
                XMessageIts.Mensagem("Nada a exportar !");
            }
            else
            {
                if (gridView1.DataSource != null)
                {
                    string pdfName = "export_cambio_pdf" + DataUtil.ToDateSql();
                    string pdf = Path.Combine(FileManagerIts.DeskTopPath, pdfName) + ".pdf";
                    FileManagerIts.DeleteFile(pdf);

                    gridControl1.ExportToPdf(pdf);
                    FileManagerIts.OpenFromSystem(pdf);
                }
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            string msg = "";
            var dtInicio = dateEditInicio.DateTime;
            var dtFim = dateEditFim.DateTime;

            if (dtInicio.Date > dtFim.Date)
            {
                msg = ("O período inicial não pode ser superior ao período final!");
            }
            else if (dtInicio.Date == dtFim.Date)
            {
                msg = ("O período inicial não pode ser igual período final!");
            }
            else if (dtInicio.Date > DateTime.Now.Date)
            {
                msg = ("O período inicial não pode ser superior a data do dia!");
            }
            //else if( DataUtil.CalcularDias(dtInicio, dtFim) < 2)
            //msg = ("O período informado deve possuir um intervalo de pelo menos 2 dias.");
            else
                msg = null;

            if (string.IsNullOrEmpty(msg))
            {
                var moeda = cbMoedas.SelectedItem as Moeda;
                if (moeda != null)
                {
                    using (var bacen = new WSBacenCambio())
                    {
                        var lista = await XFrmWait.StartTask(
                            Task.Run(() => bacen.GetCotacaoMonetariaFromBacen(
                                       dateEditInicio.DateTime, dateEditFim.DateTime, moeda)),
                                       "Filtrando moeda: " + moeda);

                        this.gridControl1.DataSource = lista;
                    }
                }
            }
            else
            {
                XMessageIts.Advertencia(msg);
            }
        }

        private async void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (var ctx = new CambioContext())
            //{
            //    ctx.LazyLoading(false);
            //    var moedas = await ctx.MoedaDao.FindAllAsync();
            //    cbMoedas.AddList<Moeda>(moedas);
            //    //cbMoedas.BeginInvoke(new Action(()=>{
            //    //    cbMoedas.AddList<Moeda>(moedas);

            //    //}));
            //}
        }

        private void barBtnCotacaoDia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new XFrmCambio().Show();
        }

        private async void barBtnHistoricoCotacaoTodasMoedas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lista = new List<CotacaoMonetaria>();
            var bacen = new WSBacenCambio();
            for (int i = 0; i < cbMoedas.GetItensCount(); i++)
            {
                cbMoedas.SelectedIndex = i;

                var moeda = cbMoedas.SelectedItem as Moeda;
                if (moeda != null)
                {
                    try
                    {
                        var aux = await XFrmWait.StartTask(Task.Run(() =>
                                   bacen.GetCotacaoMonetariaFromBacen(
                                       dateEditInicio.DateTime, dateEditFim.DateTime, moeda)), "Filtrando moeda: " + moeda);
                        lista.AddRange(aux);
                        this.gridControl1.DataSource = lista;
                        this.gridView1.RefreshData();
                    }
                    catch (BacenCambioException ex)
                    {
                        ex.ShowExceptionMessage();
                        return;
                    }
                }
            }
            bacen.Dispose();

        }

        #endregion

        private void XFrmCotacaoMonetaria_Shown(object sender, EventArgs e)
        {
            barBtnRefresh_ItemClick(null, null);
        }

        private void XFrmCotacaoMonetaria_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
                btnFiltrar_Click(null, null);
        }

        private void btnFiltrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
                btnFiltrar_Click(null, null);
        }
    }
}