using System.Collections.Generic;
using ITSolution.Framework.Enumeradores;

namespace ITSolution.Framework.Web.Bacen
{
    /// <summary>
    /// Representa as moedas principais a serem exibidas na cotação cambial do dia.
    /// </summary>
    public class CurrencyExchange
    {
        public CotacaoMonetaria Dolar { get; private set; }
        public CotacaoMonetaria Euro { get; private set; }
        public CotacaoMonetaria Iene { get; private set; }
        public CotacaoMonetaria LibraEsterlina { get; private set; }
        public CotacaoMonetaria FrancoSuico { get; private set; }
        public CotacaoMonetaria CoroaDinamarquesa { get; private set; }
        public CotacaoMonetaria CoroaNorueguesa { get; private set; }
        public CotacaoMonetaria CoroaSueca { get; private set; }
        public CotacaoMonetaria DolarAustraliano { get; private set; }
        public CotacaoMonetaria DolarCanadense { get; private set; }

        public List<CotacaoMonetaria> Cotacoes { get; }
        public CurrencyExchange()
        {
            this.Cotacoes = new List<CotacaoMonetaria>();
            this.Dolar = new CotacaoMonetaria();
            this.Euro = new CotacaoMonetaria();
            this.Iene = new CotacaoMonetaria();
            this.LibraEsterlina = new CotacaoMonetaria();
            this.FrancoSuico = new CotacaoMonetaria();
            this.CoroaDinamarquesa = new CotacaoMonetaria();
            this.CoroaNorueguesa = new CotacaoMonetaria();
            this.CoroaSueca = new CotacaoMonetaria();
            this.DolarAustraliano = new CotacaoMonetaria();
            this.DolarCanadense = new CotacaoMonetaria();
        }

        public void AddCurrencyExchange(CotacaoMonetaria cot)
        {
            var codWs = (TypeCodigoBacen)cot.Moeda.CodigoWSCompra;
            switch (codWs)
            {
                case TypeCodigoBacen.DolarCompra:
                    this.Dolar = cot;
                    break;

                case TypeCodigoBacen.EuroCompra:
                    this.Euro = cot;
                    break;

                case TypeCodigoBacen.IeneCompra:
                    this.Iene = cot;
                    break;

                case TypeCodigoBacen.LibraEsterlinaCompra:
                    this.LibraEsterlina = cot;
                    break;

                case TypeCodigoBacen.FrancoSuicoCompra:
                    this.FrancoSuico = cot;
                    break;

                case TypeCodigoBacen.CoroaDinamarquesaCompra:
                    this.CoroaDinamarquesa = cot;
                    break;

                case TypeCodigoBacen.CoroaNorueguesaCompra:
                    this.CoroaNorueguesa = cot;
                    break;

                case TypeCodigoBacen.CoroaSuecaCompra:
                    this.CoroaSueca = cot;
                    break;

                case TypeCodigoBacen.DolarAustralianoCompra:
                    this.DolarAustraliano = cot;
                    break;

                case TypeCodigoBacen.DolarCanadenseCompra:
                    this.DolarCanadense = cot;
                    break;

            }
            this.Cotacoes.Add(cot);
        }

    }
}
