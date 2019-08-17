using System;

namespace ITSolution.Framework.Ticket.Bancos
{
    public class BancoReal : AbstractBank
    {

        public override short CodigoBanco
        {
            get
            {
                return 356;
            }
        }
        public BancoReal()
        {
            this.Carteira = "57";
            this.NossoNumero = "92082835";
            this.NumeroDocumento = "1008073";
        }
    }
}
