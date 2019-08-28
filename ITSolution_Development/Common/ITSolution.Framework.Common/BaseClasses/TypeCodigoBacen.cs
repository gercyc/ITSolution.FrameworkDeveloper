using System.ComponentModel;

namespace ITSolution.Framework.Enumeradores
{
    public enum TypeCodigoBacen
    {
        [Description("Dólar (venda)")]
        DolarVenda = 1,

        [Description("Dólar (compra)")]
        DolarCompra = 10813,

        [Description("Euro (venda)")]
        EuroVenda = 21619,

        [Description("Euro (compra)")]
        EuroCompra = 21620,

        [Description("Iene (venda)")]
        IeneVenda = 21621,

        [Description("Iene (compra)")]
        IeneCompra = 21622,

        [Description("Libra esterlina (venda)")]
        LibraEsterlinaVenda = 21623,

        [Description("Libra esterlina (compra)")]
        LibraEsterlinaCompra = 21624,

        [Description("Franco Suíço (venda)")]
        FrancoSuicoVenda = 21625,

        [Description("Franco Suíço (compra)")]
        FrancoSuicoCompra = 21626,

        [Description("Coroa Dinamarquesa (venda)")]
        CoroaDinamarquesaVenda = 21627,

        [Description("Coroa Dinamarquesa (compra)")]
        CoroaDinamarquesaCompra = 21628,

        [Description("Coroa Norueguesa (venda)")]
        CoroaNorueguesaVenda = 21629,

        [Description("Coroa Norueguesa (compra)")]
        CoroaNorueguesaCompra = 21630,

        [Description("Coroa Sueca (venda)")]
        CoroaSuecaVenda = 21631,

        [Description("Coroa Sueca (compra)")]
        CoroaSuecaCompra = 21632,

        [Description("Dólar Australiano (venda)")]
        DolarAustralianoVenda = 21633,

        [Description("Dólar Australiano (compra)")]
        DolarAustralianoCompra = 21634,

        [Description("Dólar Canadense (venda)")]
        DolarCanadenseVenda = 21635,

        [Description("Dólar Canadense (compra)")]
        DolarCanadenseCompra = 21636,

        [Description("Real R$")]
        Real = 0,

       [Description("Todas as moedas")]
        TodasMoedas = -1
    }
}
