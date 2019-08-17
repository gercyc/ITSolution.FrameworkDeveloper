using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Enumeradores;
using ITSolution.Framework.GuiUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolution.Framework.Web.Bacen
{
    public partial class XFrmCambio_OLD :  DevExpress.XtraEditors.XtraForm
    {

        private IllustrateLabel _ilustrator;

        public XFrmCambio_OLD()
        {
            InitializeComponent();

        }

        private string getTextHtml(CotacaoMonetaria cot)
        {
            string html = "<u>" + cot.Moeda + "</u><br>" +
                            "Compra: " + cot.ValorCompra.ToString("N4") +
                            "<br>Venda: " + cot.ValorVenda.ToString("N4");
            return html;
        }

        //Cotacao cambial do dia
        private void showCotacaoCambial()
        {
            using (var _wsBacen = new WSBacenCambio())
            {
                //cada chamada já realizada 
                //implica em uma inserção de um tupla se não existir 
                //ou atualização se existir
                var cexchange = _wsBacen.GetCurrencyExchange();

                var dolarEua = cexchange.Dolar;
                var euro = cexchange.Euro;
                var iene = cexchange.Iene;
                var libra = cexchange.LibraEsterlina;
                var francoSuico = cexchange.FrancoSuico;
                var coroaDina = cexchange.CoroaDinamarquesa;
                var coroaNorueguesa = cexchange.CoroaNorueguesa;
                var coroaSueca = cexchange.CoroaSueca;
                var dolarAustraliano = cexchange.DolarAustraliano;
                var dolarCanadense = cexchange.DolarCanadense;

                //antes
                /*var dolarEua = _wsBacen.GetCotacaoDolar();
                var euro = _wsBacen.GetCotacaoEuro();
                var iene = _wsBacen.GetCotacaoIene();
                var libra = _wsBacen.GetCotacaoLibra();
                var francoSuico = _wsBacen.GetCotacaoFrancoSuico();
                var coroaDina = _wsBacen.GetCotacaoCoroaDinamarquesa();
                var coroaNorueguesa = _wsBacen.GetCotacaoCoroaNorueguesa();
                var coroaSueca = _wsBacen.GetCotacaoCoroaSueca();
                var dolarAustraliano = _wsBacen.GetCotacaoDolarAustraliano();
                var dolarCanadense = _wsBacen.GetCotacaoDolarCanadense();

                lastQuote.Add(dolarEua);
                lastQuote.Add(euro);
                lastQuote.Add(iene);
                lastQuote.Add(libra);
                lastQuote.Add(francoSuico);
                lastQuote.Add(coroaDina);
                lastQuote.Add(coroaNorueguesa);
                lastQuote.Add(coroaSueca);
                lastQuote.Add(dolarAustraliano);
                lastQuote.Add(dolarCanadense);*/


                //exibe as cotação de compra e venda das moedas
                this.tileItemDolarEUA.Text = getTextHtml(dolarEua);
                this.tileItemEuro.Text = getTextHtml(euro);
                this.tileItemIene.Text = getTextHtml(iene);
                this.tileItemLibraEsterlina.Text = getTextHtml(libra);
                this.tileItemFrancoSuico.Text = getTextHtml(francoSuico);
                this.tileItemCoroaDinamarquesa.Text = getTextHtml(coroaDina);
                this.tileItemCoroaNorueguesa.Text = getTextHtml(coroaNorueguesa);
                this.tileItemCoroaSueca.Text = getTextHtml(coroaSueca);
                this.tileItemDolarAustraliano.Text = getTextHtml(dolarAustraliano);
                this.tileItemDolarCanadense.Text = getTextHtml(dolarCanadense);

                if (this._ilustrator == null)
                {
                    string msg = _wsBacen.GetCotacaoDolar().ToString();

                    this._ilustrator = new IllustrateLabel(this, this.lblFonte1, msg);
                    Task.Run(() => this._ilustrator.RunMoving());

                }

                //para chamada assincrona
                gridControl1.BeginInvoke(new Action(() =>
                {
                    gridControl1.DataSource = cexchange.Cotacoes;
                }));

                /*dashboardViewer1.BeginInvoke(new Action(() =>
                {
                    var dash = Path.Combine(Application.StartupPath, "Dashboards", "Dashboard1.xml");

                    if (File.Exists(dash))
                        this.dashboardViewer1.LoadDashboard(dash);

                }));*/
            }


        }

        public void RefreshCotacaoCambio()
        {
            XFrmWait.StartTask(Task.Run(() => showCotacaoCambial()), "Obtendo cotação cambial");
        }

        //exibe a cotação da moeda pelo clique no tile
        private async void showCotacaoCotacaoMonetaria(TypeCodigoBacen typeCod)
        {
            using (var _wsBacen = new WSBacenCambio())
            {
                try
                {
                    var codigo = (long)typeCod;
                    var dataAtual = DateTime.Now;
                    var moeda = new MoedaDaoManager().GetMoedaByCodigo((long)codigo);

                    gridControl1.DataSource = await Task.Run(() =>
                        _wsBacen.GetCotacaoMonetariaFromBacen(dataAtual.AddDays(-7), dataAtual, moeda));

                    //var row = cardView1.GetItens<CotacaoMonetaria>().FirstOrDefault();
                    var ds = gridView1.DataSource as List<CotacaoMonetaria>;
                    var row = ds.FirstOrDefault();
                    if (row != null)
                        lblFonte1.Text = row.ToString();

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
        }

        private void XFrmCambio_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F5)
                RefreshCotacaoCambio();
        }

        private void tileItemEuro_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.EuroCompra);
        }

        private void tileItemDolarEUA_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.DolarCompra);
        }

        private void tileItemDolarCanadense_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.DolarCanadenseCompra);
        }

        private void tileItemDolarAustraliano_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.DolarAustralianoCompra);
        }

        private void tileItemLibraEsterlina_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.LibraEsterlinaCompra);
        }

        private void tileItemIene_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.IeneCompra);
        }

        private void tileItemFrancoSuico_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.FrancoSuicoCompra);
        }

        private void tileItemCoroaNorueguesa_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.CoroaNorueguesaCompra);
        }

        private void tileItemCoroaDinamarquesa_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.CoroaDinamarquesaCompra);
        }

        private void tileItemCoroaSueca_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            showCotacaoCotacaoMonetaria(TypeCodigoBacen.CoroaSuecaCompra);
        }

        private void XFrmCambio_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //this.wsBacen.Dispose();
            if (this._ilustrator != null)
                this._ilustrator.Running = false;
        }

    }
}



