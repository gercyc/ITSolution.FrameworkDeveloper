using System.ComponentModel;

namespace ITSolution.Framework.Enumeradores
{
    public enum TypeContaBancaria
    {
        Corrente,
        [Description("Poupança")]
        Poupanca,
        Conjunta
    }
}
