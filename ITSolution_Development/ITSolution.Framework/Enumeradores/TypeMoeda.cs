using System.ComponentModel;

namespace ITSolution.Framework.Enumeradores
{
    public enum TypeMoeda
    {
        //0 nao indefinido => evita null pointer

        [Description("Real R$")]
        Real = 1,

        [Description("Euro (€) ")]
        Euro = 2,

        [Description("Libra Esterlina")]
        LibraEsterlina= 3,

        [Description("Franco Suíço")]
        FrancoSuico = 4,
    }
}
