using ITSolution.Framework.Common.WSBacen;
using ITSolution.Framework.Enumeradores;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Linq;

//Fonte
//http://blog.tiagocrizanto.com/configuracoes-do-webservice-do-banco-central-cotacoes-diversas/
//endereço do webservice 
//https://www3.bcb.gov.br/sgspub/JSP/sgsgeral/FachadaWSSGS.wsdl
namespace ITSolution.Framework.Web.Bacen
{
    /// <summary>
    /// Webservice do banco do brasil    
    /// </summary>
    public class WSBacenCambio : IDisposable
    {
        public FachadaWSSGSClient ServiceClient { get; private set; }
        public WSBacenCambio()
        {
            this.ServiceClient = new Common.WSBacen.FachadaWSSGSClient();
        }

        /// <summary>
        /// Obtém a cotação a partir do código.
        /// </summary>
        /// <param name="typeCodigo"></param>
        /// <returns></returns>
        public CotacaoMonetaria GetCotacaoByCodigo(TypeCodigoBacen typeCodigo)
        {
            try
            {
                var cot = getLastCotacaoAux((long)typeCodigo);
                return new CotacaoMonetaria(cot.DataCotacao, cot.ValorCotacao,
                                            cot.ValorCotacao, cot.SerieVo);
            }
            catch (BacenCambioException ex)
            {
                ex.ShowExceptionMessage();
                return null;
            }
        }


        #region Principais moedas

        /// <summary>
        /// Obtem a cotação das principais moedas referidas no sistema. 
        /// </summary>
        /// <returns></returns>
        public CurrencyExchange GetCurrencyExchange()
        {
            CurrencyExchange cotacao = new CurrencyExchange();

            //using (var ctx = new CambioContext())
            //{
            //    DateTime data = DateTime.Now.ToDateZerada();

            //    if (data.DayOfWeek == DayOfWeek.Saturday)
            //        data = data.AddDays(-1);
            //    else if (data.DayOfWeek == DayOfWeek.Sunday)
            //    {
            //        data = data.AddDays(-2);
            //    }

            //    //localize as cotações do dia
            //    var cotExist = ctx.CotacaoMonetariaDao
            //        .Where(c => c.DataCotacao.ToDateZerada() == data)
            //        .ToList();

            //    if (cotExist.Count >= 9)
            //    {
            //        //localizei primeiro a cotação no banco
            //        //isso aqui eh mais rapido q obter da internet
            //        cotacao.Cotacoes.AddRange(cotExist);
            //    }
            //    else
            //    {
            //        var moedas = ctx.MoedaDao.FindAll();

            //        foreach (var m in moedas)
            //        {
            //            try
            //            {
            //                //obtem do webservice mesmo
            //                //persiste a cotação
            //                CotacaoMonetaria cotNew = getCotacao((TypeCodigoBacen)m.CodigoWSCompra,
            //                    (TypeCodigoBacen)m.CodigoWSVenda );

            //                //sempre add 
            //                cotacao.AddCurrencyExchange(cotNew);

            //                SaveCotacaoMonetaria(ctx, cotNew);

            //            }
            //            catch (Exception ex)
            //            {
            //                LoggerUtilIts.GenerateLogs(ex, "Falha no WSBacenCambio", "Falha na cotação cambial.");
            //            }
            //        }
            //    }
            //}
            return cotacao;
        }


        //Tinha feito um metodo pra cada moeda 
        //Pois eu nao tinha os codigos de moedas salvos no meu banco
        //Vou deixar eles aqui por enquanto
        public CotacaoMonetaria GetCotacaoDolarCanadense()
        {
            return getCotacao(TypeCodigoBacen.DolarCanadenseCompra, TypeCodigoBacen.DolarCanadenseVenda);
        }

        public CotacaoMonetaria GetCotacaoDolarAustraliano()
        {
            //DÓLAR AUSTRALIANO	21634	21633
            return getCotacao(TypeCodigoBacen.DolarAustralianoCompra, TypeCodigoBacen.DolarAustralianoVenda);
        }

        public CotacaoMonetaria GetCotacaoCoroaSueca()
        {
            return getCotacao(TypeCodigoBacen.CoroaSuecaCompra, TypeCodigoBacen.CoroaSuecaVenda);
        }

        public CotacaoMonetaria GetCotacaoCoroaNorueguesa()
        {
            return getCotacao(TypeCodigoBacen.CoroaNorueguesaCompra, TypeCodigoBacen.CoroaNorueguesaVenda);
        }

        public CotacaoMonetaria GetCotacaoCoroaDinamarquesa()
        {
            return getCotacao(TypeCodigoBacen.CoroaDinamarquesaCompra, TypeCodigoBacen.CoroaDinamarquesaVenda);
        }

        public CotacaoMonetaria GetCotacaoFrancoSuico()
        {
            return getCotacao(TypeCodigoBacen.FrancoSuicoCompra, TypeCodigoBacen.FrancoSuicoVenda);
        }

        public CotacaoMonetaria GetCotacaoLibra()
        {
            return getCotacao(TypeCodigoBacen.LibraEsterlinaCompra, TypeCodigoBacen.LibraEsterlinaVenda);
        }

        public CotacaoMonetaria GetCotacaoIene()
        {

            return getCotacao(TypeCodigoBacen.IeneCompra, TypeCodigoBacen.IeneVenda);
        }

        public CotacaoMonetaria GetCotacaoDolar()
        {
            return getCotacao(TypeCodigoBacen.DolarCompra, TypeCodigoBacen.DolarVenda);
        }

        public CotacaoMonetaria GetCotacaoEuro()
        {
            return getCotacao(TypeCodigoBacen.EuroCompra, TypeCodigoBacen.EuroVenda);
        }


        #endregion

        /// <summary>
        /// Obtem a cotação cambial da moeda no site do banco do brasil
        ///A data de inicio deve ser 2 dias inferior a data atual
        /// </summary>
        /// <returns></returns>
        public List<CotacaoMonetaria> GetCotacaoMonetariaFromBacen(DateTime dtInicio, DateTime dtFim, Moeda moeda)
        {
            var cotacoes = new List<CotacaoMonetaria>();

            try
            {
                var compra = createCotacaoCambial(dtInicio, dtFim, moeda.CodigoWSCompra);
                var venda = createCotacaoCambial(dtInicio, dtFim, moeda.CodigoWSVenda);
                //uni as cotações
                cotacoes.AddRange(unionCotacaoCambial(moeda, compra, venda));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(BacenCambioException))
                {
                    BacenException be = ex as BacenCambioException;
                    be.ShowExceptionMessage();
                }
                else
                {
                    XMessageIts.Advertencia(ex.Message);
                }
                return null;
            }
            return cotacoes;
        }

        /// <summary>
        /// Obtem a cotação cambial do periodo no site do banco do brasil
        /// A data de inicio deve ser 2 dias inferior a data atual
        /// </summary>
        /// <returns></returns>
        public List<CotacaoMonetaria> GetCotacaoMonetariaFromBacen(DateTime dtInicio, DateTime dtFim)
        {

            var moedas = new MoedaDaoManager().FindAll();
            var cotacoes = new List<CotacaoMonetaria>();
            foreach (var m in moedas)
            {
                try
                {
                    //cotação de compra
                    var compra = createCotacaoCambial(dtInicio, dtFim, m.CodigoWSCompra);
                    //cotação de venda
                    var venda = createCotacaoCambial(dtInicio, dtFim, m.CodigoWSVenda);
                    //uni as cotãções
                    cotacoes.AddRange(unionCotacaoCambial(m, compra, venda));

                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(BacenException))
                    {
                        BacenException be = ex as BacenException;
                        be.ShowExceptionMessage();
                    }
                    else
                    {
                        XMessageIts.Advertencia(ex.Message);
                        return null;
                    }
                }
            }

            return cotacoes;
        }

        public List<CotacaoMonetaria> GetCotacoesIndicadoresBacen()
        {
            var cotacoes = new List<CotacaoMonetaria>();

            //using (var ctx = new CambioContext())
            //{
            //    try
            //    {
            //        //recupera as moedas
            //        var indicadores = CambioContext.Instance.IndicadoresBacenDao
            //                        .FindAll().ToList();
            //        //.Where(m => m.NomeCompletoMoeda.ToLower().Contains("peso")).ToList();

            //        foreach (var ind in indicadores)
            //        {
            //            try
            //            {
            //                var cot = getLastCotacaoAux(ind.CodigoMoeda);
            //                var cotacao = new CotacaoMonetaria(cot.DataCotacao, cot.ValorCotacao, cot.ValorCotacao, ind);
            //                cotacoes.Add(cotacao);
            //            }
            //            catch (BacenCambioException ex)
            //            {
            //                XMessageIts.Erro("Falha ao informações dos indicadores\n\n" +
            //                    "Erro:" + ex.Message, ex.Title);
            //                return null;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string msg = "Nenhum indicador localizado";
            //        string title = "Falha na listagem de indicadores.";
            //        XMessageIts.Advertencia(msg, title);
            //        LoggerUtilIts.GenerateLogs(ex, msg + "\n" + title);
            //    }
            //}
            return cotacoes;
        }

        /// <summary>
        /// Cria uma lista de cotação cambial a partir do codigo
        /// Lança BacenException
        /// Restrições<br>
        ///Apesar do metodo aceitar varios codigos o webservice é muito sensivel a erros quando o periodo é longo
        ///Não é permitido que a data inicia (dtInicio) seja igual ou superior a data atual
        ///A data fim eh filtrada substraindo um dia da mesma
        ///Entao sempre é adicionado 1 dia na data final (dtFim)
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="dtInicio">Periodo inicial</param>
        /// <param name="dtFim">Periodo Final</param>
        /// <returns>List<CotacaoAux></returns>
        private List<CotacaoAux> createCotacaoCambial(DateTime dtInicio, DateTime dtFim, long codigo)
        {
            //getValoresSeriesVO – Recupera os valores de uma ou mais séries 
            //dentro de um determinado período e retorna o resultado em forma de Array de objetos 
            //do tipo WSSerieVO.
            //Parâmetros:
            //long[] codigosSeries – Lista(array) dos códigos das séries.
            //String dataInicio – String contendo a data (dd / MM / aaaa) inicial.
            //String dataFim – String contendo a data(dd / MM / aaaa) final.
            //Retorno:
            //WSSerieVO – Lista(array) de objeto série.

            if (dtInicio.Date > dtFim.Date)
            {
                throw new Exception("O período inicial não pode ser superior ao período final!");
            }
            if (dtInicio.Date == dtFim.Date)
            {
                throw new Exception("O período inicial não pode ser igual período final!");
            }
            if (dtInicio.Date > DateTime.Now.Date)
            {
                throw new Exception("O período inicial não pode ser superior a data do dia!");
            }

            var dataFinal = dtFim.Date;

            dtFim.Date.AddDays(1);
            var cotacoes = new List<CotacaoAux>();
            try
            {

                var seriesVO = this.ServiceClient
                      .getValoresSeriesVO(new long[] { codigo },
                        dtInicio.Date.ToShortDateString(), dtFim.Date.ToShortDateString());


                foreach (var serie in seriesVO)
                {
                    //var nome = serie.fullName;
                    foreach (var valorSerie in serie.valores)
                    {
                        var cot = new CotacaoAux(serie, valorSerie);

                        //preciso checar isso pq o webservice nao trata as datas
                        //para evitar um erro estou trazendo um dia a mais na data final
                        //se a data for menor ou igual eu add na lista de cotação
                        //caso contrario ela nao faz parte da busca esperada pelo usuario
                        if (cot.DataCotacao <= dtFim.Date)
                            cotacoes.Add(cot);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new BacenCambioException(ex, "Falha ao obter cotação no período: " +
                                            dtInicio.ToShortDateString() + " á " +
                                            dtFim.ToShortDateString());
            }
            return cotacoes;
        }

        /// <summary>
        /// Gera uma lista de cotãção com o preço de compra e venda da moeda
        /// </summary>
        /// <param name="moeda"></param>Moeda
        /// <param name="compra"></param>Lista com valores comrpa
        /// <param name="venda"></param>Lista com valores venda
        /// <returns>List<CotacaoMonetaria></returns>
        private List<CotacaoMonetaria> unionCotacaoCambial(Moeda moeda, List<CotacaoAux> compra, List<CotacaoAux> venda)
        {
            int count = compra.Count;
            List<CotacaoMonetaria> cotacoes = new List<CotacaoMonetaria>();

            if (count > venda.Count)
            {
                //use o menor
                count = venda.Count;
            }
            for (int i = 0; i < count; i++)
            {
                var c = compra[i];
                var v = venda[i];

                var cot = new CotacaoMonetaria();
                //compra e venda tem as mesma datas
                cot.DataCotacao = c.DataCotacao;
                cot.ValorCompra = c.ValorCotacao;
                cot.ValorVenda = v.ValorCotacao;
                cot.IdMoeda = moeda.IdMoeda;
                cot.Moeda = moeda;
                cot.AddReference(c.SerieVo);
                cotacoes.Add(cot);
            }

            return cotacoes;
        }


        /// <summary>
        /// Libera o objeto do webservice do bacen.
        /// </summary>
        public void Dispose()
        {
            this.ServiceClient.Close();
        }

        /// <summary>
        /// Obtem a cotação a partir do código
        /// Lança exceção: BacenCambioException
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private CotacaoAux getLastCotacaoAux(long codigo)
        {
            try
            {
                //referencias da cotação
                var vo = this.ServiceClient.getUltimoValorVO(codigo);

                //ultima cotação
                var v = vo.ultimoValor;

                return new CotacaoAux(vo, v);
            }
            catch (Exception ex)
            {
                throw new BacenCambioException(ex, codigo.ToString());
            }

        }

        private CotacaoMonetaria getCotacao(TypeCodigoBacen codigoCompra, TypeCodigoBacen codigoVenda)
        {
            long codCompra = (long)codigoCompra;
            long codVenda = (long)codigoVenda;

            var cotCompraAux = getLastCotacaoAux(codCompra);
            var cotVendaAux = getLastCotacaoAux(codVenda);

            //a data do cotCompraAux e cotVendaAux sao iguais
            var cot = new CotacaoMonetaria(cotVendaAux.DataCotacao, cotCompraAux.ValorCotacao,
                                           cotVendaAux.ValorCotacao, cotCompraAux.SerieVo);

            cot.AddReference(cotCompraAux.SerieVo);

            //using (var ctx = new CambioContext())
            //{
            //    try
            //    {
            //        //recupera a moeda pelo codigo de compra/venda
            //        Moeda moeda = ctx.MoedaDao.First(m =>
            //            m.CodigoWSCompra == codCompra || m.CodigoWSVenda == codVenda);

            //        cot.Moeda = moeda;
            //        SaveCotacaoMonetaria(ctx, cot);
            //    }
            //    catch (Exception ex)
            //    {
            //        string msg = "Moeda não foi localizada";
            //        string title = "Não foi possível obter a atualização cambial";
            //        XMessageIts.Advertencia(msg, title);

            //        LoggerUtilIts.GenerateLogs(ex, msg + "\n" + title);

            //        throw ex;
            //    }
            //}
            return cot;
        }

        /// <summary>
        /// Salva ou atualiza cotação
        /// </summary>
        /// <param name="ctx"></param> Contexto
        /// <param name="cot"></param>Cotação a ser salva
        private void SaveCotacaoMonetaria(string ctx, CotacaoMonetaria cotacao)
        {
      
            //use o codigo de compra mesmo 
            long codigo = cotacao.Moeda.CodigoWSCompra;

            try
            {
           
                ////recupera a moeda pelo codigo de compra/venda
                //Moeda moeda = cotacao.Moeda;

                //if(moeda==null || moeda.IdMoeda==0)
                //    moeda = ctx.MoedaDao.First(m =>
                //                        m.CodigoWSCompra == codigo 
                //                        || m.CodigoWSVenda == codigo);

                //try
                //{
                //    //recupera a cotação
                //    var current = ctx.CotacaoMonetariaDao
                //        .First(c => c.DataCotacao.Date == cotacao.DataCotacao
                //                            && c.IdMoeda == moeda.IdMoeda);

                //    //e atualiza ela
                //    current.ValorCompra = cotacao.ValorCompra;
                //    current.ValorVenda = cotacao.ValorVenda;
                //    current.DataCotacao = cotacao.DataCotacao;
                //    //atualiza no banco
                //    ctx.CotacaoMonetariaDao.Update(current);

                //}
                //catch (Exception ex)
                //{
                //    //nao tem cotação add
                //    Console.WriteLine("Criando um nova cotação: =>" + ex.Message);
         
                //    //FK
                //    cotacao.IdMoeda = moeda.IdMoeda;
                //    //salva no banco 
                //    ctx.CotacaoMonetariaDao.Save(cotacao);

                //}
            }
            catch (Exception ex)
            {
                string msg = "Moeda não foi localizada";
                string title = "Problema na rotina de atualização cambial";
                XMessageIts.Advertencia(msg, title);

                LoggerUtilIts.GenerateLogs(ex, msg + "\n" + title);
            }
        }

        #region Classe interna para manusear a cotacao

        private class CotacaoAux
        {
            public decimal ValorCotacao { get; set; }
            public DateTime DataCotacao { get; set; }
            //public long Codigo { get; set; }

            public WSSerieVO SerieVo { get; set; }

            public CotacaoAux(WSSerieVO serieVo, WSValorSerieVO value)
            {
                this.SerieVo = serieVo;
                this.ValorCotacao = ParseUtil.ToDecimal(value.svalor);
                this.DataCotacao = new DateTime(value.ano, value.mes, value.dia);
                //this.Codigo = value.oidSerie;
            }

        }
        #endregion

    }

}