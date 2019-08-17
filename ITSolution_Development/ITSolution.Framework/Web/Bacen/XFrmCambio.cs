using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Web.Bacen
{
    public partial class XFrmCambio : DevExpress.XtraEditors.XtraForm
    {

        private IllustrateLabel _ilustrator;

        public XFrmCambio()
        {

            InitializeComponent();

        }

        //Cotacao cambial do dia
        private void showCotacaoCambial()
        {
            using (var wsBacen = new WSBacenCambio())
            {
                //cada chamada já realizada 
                //implica em uma inserção de um tupla se não existir 
                //ou atualização se existir
                var cexchange = wsBacen.GetCurrencyExchange();

                if (this._ilustrator == null)
                {
                    var first = cexchange.Cotacoes.FirstOrDefault();
                    string msg = first?.ToString() ?? "Cotação Cambial";

                    this._ilustrator = new IllustrateLabel(this, this.lblFonte1, msg);
                    Task.Run(() => this._ilustrator.RunMoving());

                }

                if (this.InvokeRequired)
                {
                    //para chamada assincrona
                    gridControl1.BeginInvoke(new Action(() =>
                    {
                        gridControl1.DataSource = cexchange.Cotacoes;
                    }));

                    gridControl2.BeginInvoke(new Action(() =>
                    {
                        gridControl2.DataSource = cexchange.Cotacoes;

                        gridView1.ExpandAllGroups();
                        gridView1.FocusedRowHandle = 1; //foco no euro

                    }));


                    /*dashboardViewer1.BeginInvoke(new Action(() =>
                    {
                        var dash = Path.Combine(Application.StartupPath, "Dashboards", "Dashboard1.xml");
    
                        if (File.Exists(dash))
                            this.dashboardViewer1.LoadDashboard(dash);
    
                    }));*/
                }
            }
        }

        public void RefreshCotacaoCambio()
        {
            XFrmWait.StartTask(Task.Run(() => showCotacaoCambial()), "Obtendo cotação cambial");

        }

        //exibe a cotação da moeda pelo clique no tile
        private async void showCotacaoMonetariaFromMoeda(CotacaoMonetaria m)
        {

            using (var _wsBacen = new WSBacenCambio())
            {
                try
                {
                    var codigo = m.Moeda.CodigoWSCompra;
                    var dataAtual = DateTime.Now;
                    var moeda = new MoedaDaoManager().GetMoedaByCodigo((long)codigo);

                    var cotacoes = await Task.Run(() =>
                        _wsBacen.GetCotacaoMonetariaFromBacen(dataAtual.AddDays(-7), dataAtual, moeda));

                    gridControl2.DataSource = cotacoes;
                    
                    var row = cotacoes.FirstOrDefault();
                    if (row != null)
                        lblFonte1.Text = row.ToString();

                    gridView1.ExpandAllGroups();

                }
                catch (BacenCambioException ex)
                {
                    ex.ShowExceptionMessage();
                }
            }
        }


        private void XFrmCambio_Shown(object sender, System.EventArgs e)
        {
            RefreshCotacaoCambio();

            var x = InfoSystemUtil
                .SizeScreen();

            if (x.Width < this.Width)
                this.Size = x ;

            //foco na linha do euro 
            //essa eh a linha do euro
            gridView1.FocusedRowHandle = 1; 

        }

        private void XFrmCambio_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshCotacaoCambio();
        }

        private void XFrmCambio_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //this.wsBacen.Dispose();
            if (this._ilustrator != null)
                this._ilustrator.Running = false;
        }



        private void tileView1_ItemPress(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            var row = tileView1.GetFocusedRow() as CotacaoMonetaria;
            if (row != null)
                showCotacaoMonetariaFromMoeda(row);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.ExpandAllGroups();
            gridView1.ExpandGroupRow(1);
        }
    }
}



