using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;

namespace ITSolution.Framework.Web.Bacen
{
    public class MoedaDaoManager
    {
        public List<Moeda> FindAll()
        {
            return new List<Moeda>();

            //using (var ctx = new CambioContext())
            //{
            //    ctx.LazyLoading(false);
            //    var moedas = ctx.MoedaDao.FindAll();
            //    return moedas;
            //}
        }

        public Moeda GetMoedaByCodigo(long codigo)
        {
            return new Moeda();
            //using (var ctx = new CambioContext())
            //{
            //    ctx.LazyLoading(false);
            //    try
            //    {
            //        //recupera a moeda pelo codigo de compra/venda
            //        var moeda = ctx.MoedaDao.First(m =>
            //                m.CodigoWSCompra == codigo ||
            //                m.CodigoWSVenda == codigo);

            //        return moeda;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
        }

        /// <summary>
        /// Salva ou atualiza cotação
        /// </summary>
        /// <param name="ctx"></param> Contexto
        /// <param name="cot"></param>Cotação a ser salva
        public void SaveCotacaoMonetaria(CotacaoMonetaria cot)
        {

            //using (var ctx = new CambioContext())
            //{
            //    try
            //    {
            //        var cotacao = new CotacaoMonetaria(cot.DataCotacao, cot.ValorCompra, cot.ValorVenda);
            //        //FK
            //        cotacao.IdMoeda = cot.Moeda.IdMoeda;

            //        //salva no banco 
            //        ctx.CotacaoMonetariaDao.Save(cotacao);
            //    }
            //    catch (Exception ex)
            //    {
            //        string msg = "Moeda não foi localizada";
            //        string title = "Problema na rotina de atualização cambial";
            //        XMessageIts.Advertencia(msg, title);

            //        LoggerUtilIts.GenerateLogs(ex, msg + "\n" + title);
            //    }
            //}
        }

    }
}
